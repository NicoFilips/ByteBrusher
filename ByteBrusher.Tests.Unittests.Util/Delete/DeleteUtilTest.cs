using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Util.Abstraction.Hash.Models;
using ByteBrusher.Util.Implementation.Delete;
using ErrorOr;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ByteBrusher.Tests.Unittests.Util.Delete;

public class DeleteUtilTest
{
    private Mock<IFileAbstraction> _fileAbstractionMock = new();
    private Mock<ILogger<DeleteUtil>> _loggerMock = new();
    private DeleteUtil _deleteUtil = null!;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<DeleteUtil>>();
        _fileAbstractionMock = new Mock<IFileAbstraction>();
        _deleteUtil = new DeleteUtil(_loggerMock.Object, _fileAbstractionMock.Object);
    }


    [Test]
    public void TryDelete_ShouldReturnErrorWhenDuplicatesIsEmpty()
    {
        // Arrange
        var duplicates = new List<FoundFile>();

        // Act
        ErrorOr<Deleted> result = _deleteUtil.TryDelete(duplicates);

        // Assert
        result.IsError.Should().BeTrue();
        Assert.That(result.FirstError.Code, Is.EqualTo("No duplicates found"));
    }

    [Test]
    public void TryDelete_ShouldReturnNotFoundErrorWhenFileDoesNotExist()
    {
        // Arrange
        var nonExistentFile = new FoundFile { FileInfo = new FileInfo("nonexistentfile.txt") };
        var duplicates = new List<FoundFile> { nonExistentFile };

        _fileAbstractionMock.Setup(fa => fa.Exists(nonExistentFile.FileInfo.FullName)).Returns(false);

        // Act
        ErrorOr<Deleted> result = _deleteUtil.TryDelete(duplicates);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("One or more files do not exist");
    }

    [Test]
    public void TryDelete_ShouldReturnErrorWhenNoDuplicates()
    {
        ErrorOr<Deleted> result = _deleteUtil.TryDelete(new List<FoundFile>());

        result.IsError.Should().Be(true);
        result.FirstError.Code.Should().Be("No duplicates found");
    }

    [Test]
    public void TryDelete_ShouldReturnErrorWhenFileDoesNotExist()
    {
        var files = new List<FoundFile>
        {
            new() { FileInfo  = new FileInfo("file1.txt"), FileType = new Video() },
            new() { FileInfo = new FileInfo("file2.txt"), FileType = new Image() },
        };

        _fileAbstractionMock.Setup(f => f.Exists(It.IsAny<string>())).Returns(false);

        ErrorOr<Deleted> result = _deleteUtil.TryDelete(files);

        result.IsError.Should().Be(true);
        result.FirstError.Code.Should().Be("One or more files do not exist");
    }

    [Test]
    public void TryDelete_ShouldDeleteFilesAndReturnSuccess()
    {
        var files = new List<FoundFile>
        {
            new() { FileInfo  = new FileInfo("file1.txt"), FileType = new Video() },
            new() { FileInfo = new FileInfo("file2.txt"), FileType = new Image() },
        };

        _fileAbstractionMock.Setup(f => f.Exists(It.IsAny<string>())).Returns(true);

        ErrorOr<Deleted> result = _deleteUtil.TryDelete(files);

        result.IsError.Should().Be(false);
        _fileAbstractionMock.Verify(f => f.Delete(It.IsAny<string>()), Times.Exactly(files.Count));
    }

    [Test]
    public void TryDelete_ShouldReturnErrorOnException()
    {
        var duplicates = new List<FoundFile>
        {
            new() { FileInfo  = new FileInfo("file1.txt"), FileType = new Video() },
            new() { FileInfo = new FileInfo("file2.txt"), FileType = new Image() },
        };

        _fileAbstractionMock.Setup(f => f.Exists(It.IsAny<string>())).Returns(true);
        _fileAbstractionMock.Setup(f => f.Delete(It.IsAny<string>())).Throws(new FileNotFoundException());

        ErrorOr<Deleted> result = _deleteUtil.TryDelete(duplicates);

        result.IsError.Should().Be(true);
        result.FirstError.Code.Should().Be("Unable to find the specified file.");
    }
}
