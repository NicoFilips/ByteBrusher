using Moq;
using FluentAssertions;
using NUnit.Framework;
using ByteBrusher.Util.Implementation.Hash;
using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Util.Abstraction.Hash.Models;
using Microsoft.Extensions.Logging;

namespace ByteBrusher.Tests.Unittests.Util.Hash;

public class HashUtilTest
{
    private Mock<IFileAbstraction> _fileStreamMock = new();
    private Mock<ILogger<HashUtil>> _logger = new();

    [Test]
    public async Task CompareChecksumAsync_whenMockedStream_IsEqual()
    {
        // Arrange
        _fileStreamMock = new Mock<IFileAbstraction>();
        _logger = new Mock<ILogger<HashUtil>>();
        _fileStreamMock.Setup(x => x.StartStream(It.IsAny<string>()))
                       .Returns(() =>
                                {
                                    return new MemoryStream(Array.Empty<byte>());
                                });
        var hashUtil = new HashUtil( _logger.Object,_fileStreamMock.Object);

        // Act
        bool result = await hashUtil.CompareChecksumAsync("SameFile", "SameFile");

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public Task HashUtil_WhenFileNotFound_Throw()
    {
        // Arrange
        _fileStreamMock.Setup(x => x.StartStream(It.IsAny<string>())).Throws<FileNotFoundException>();

        // Act
        HashUtil hashUtil = new( _logger.Object,_fileStreamMock.Object);

        // Assert
        Assert.ThrowsAsync<FileNotFoundException>(async () => await hashUtil.CompareChecksumAsync("test", "fileToCompare"));
        return Task.CompletedTask;
    }

    [Test]
    public async Task GetDuplicatesAsync_ShouldReturnExpectedDuplicates()
    {
        // Arrange
        var files = new List<FoundFile>
        {
            new() { FileInfo  = new FileInfo("file1.txt"), FileType = new Video() },
            new() { FileInfo = new FileInfo("file2.txt"), FileType = new Image() },
        };

        _fileStreamMock.Setup(x => x.StartStream(It.IsAny<string>()))
                       .Returns(() => new MemoryStream(Array.Empty<byte>()));

        // Act
        HashUtil hashUtil = new( _logger.Object,_fileStreamMock.Object);
        Dictionary<string, List<FoundFile>> result = await hashUtil.GetDuplicatesAsync(files);

        // Assert
        result.Should().HaveCount(2);
        //result.Should().ContainKey("file1.txt");
        //result["file1.txt"].Should().HaveCount(2);
        //result["file1.txt"][0].fileInfo.Name.Should().Be("file2.txt");
    }
}
