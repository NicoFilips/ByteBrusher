using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Core.Parameter;
using ByteBrusher.Tests.Util;
using ByteBrusher.Util.Abstraction.Delete;
using ByteBrusher.Util.Abstraction.Filter;
using ByteBrusher.Util.Abstraction.Hash;
using ByteBrusher.Util.Abstraction.Scan;
using ErrorOr;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using FluentAssertions;

namespace ByteBrusher.Tests.Integrationtests;

public class ByteBrusherClientTests
{
    private ILogger<ByteBrusherClient> _logger = null!;
    private ByteBrusherClient _byteBrusherClient = null!;
    private Mock<IFilterUtil> _filterUtil = null!;
    private Mock<IScanUtil> _scanUtil = null!;
    private Mock<IDeleteUtil> _deleteUtil = null!;
    private Mock<IHashUtil> _hashUtil = null!;
    private TemporaryDirectory _temporaryDirectory = null!;
    private string _pathToCleanUp = null!;
    private bool _deleteFlag;

    [SetUp]
    public void Setup()
    {
        var foundFiles = new List<FoundFile>();
        var duplicateFiles = new Dictionary<string, List<FoundFile>>();
        _logger = new Mock<ILogger<ByteBrusherClient>>().Object;
        _filterUtil = new Mock<IFilterUtil>();
        _filterUtil.Setup(x => x.FilterFiles(It.IsAny<List<FoundFile>>(), It.IsAny<ByteBrusherParams>())).Returns(foundFiles);
        _scanUtil = new Mock<IScanUtil>();
        _scanUtil.Setup(x => x.GetFileInfos(It.IsAny<string>())).Returns(foundFiles);
        _deleteUtil = new Mock<IDeleteUtil>();
        _hashUtil = new Mock<IHashUtil>();
        _temporaryDirectory = TemporaryDirectory.Create();
        _pathToCleanUp = _temporaryDirectory.DirectoryPath;
        _deleteFlag = true;
        _byteBrusherClient = new(_logger, _scanUtil.Object, _filterUtil.Object, _hashUtil.Object, _deleteUtil.Object);

        foundFiles.Add(FoundFilesUtil.CreateFoundFile(_temporaryDirectory.DirectoryPath, "test.mp3", new Video()));
        foundFiles.Add(FoundFilesUtil.CreateFoundFile(_temporaryDirectory.DirectoryPath, "test2.jpg", new Image()));
        foundFiles.Add(FoundFilesUtil.CreateFoundFile(_temporaryDirectory.DirectoryPath, "test3.png", new Image()));
        foundFiles.Add(FoundFilesUtil.CreateFoundFile(_temporaryDirectory.DirectoryPath, "test4.jpg", new Image()));
        foundFiles.Add(FoundFilesUtil.CreateFoundFile(_temporaryDirectory.DirectoryPath, "test5.pdf", new Document()));
        _hashUtil.Setup(x => x.GetDuplicatesAsync(It.IsAny<List<FoundFile>>())).ReturnsAsync(FoundFilesUtil.CreateDuplicateRange(foundFiles));

        duplicateFiles.Add("test.mp3", new List<FoundFile> { foundFiles[0] });
    }

    [Test]
    public async Task ByteBrusherClient_WhenNotSuccesful_ReturnTrue()
    {
        // Arrange
        _deleteUtil.Setup(x => x.TryDelete(It.IsAny<List<FoundFile>>())).Returns(new Error());

        // Act
        bool result = await _byteBrusherClient.ExecuteAsync(true, _pathToCleanUp);

        // Assert
        result.Should().Be(true);
    }

    [Test]
    public async Task ByteBrusherClient_WhenDeletedSuccesful_ReturnTrue()
    {
        // Arrange
        _deleteUtil.Setup(x => x.TryDelete(It.IsAny<List<FoundFile>>())).Returns(Result.Deleted);

        // Act
        bool result = await _byteBrusherClient.ExecuteAsync(_deleteFlag, _pathToCleanUp);

        // Assert
        result.Should().Be(true);
    }

    [Test]
    public async Task ByteBrusherClient_WhenDeletedThrows_ReturnFalse()
    {
        // Arrange
        _deleteUtil.Setup(x => x.TryDelete(It.IsAny<List<FoundFile>>())).Throws(new FileNotFoundException());

        // Act
        bool result = await _byteBrusherClient.ExecuteAsync(_deleteFlag, _pathToCleanUp);

        // Assert
        result.Should().Be(false);
    }

    [TearDown]
    public void TearDown() => _temporaryDirectory.Dispose();
}
