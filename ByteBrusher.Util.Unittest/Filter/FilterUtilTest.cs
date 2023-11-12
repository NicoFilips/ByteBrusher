using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Core.IOptions;
using ByteBrusher.Util.Abstraction.Arguments;
using ByteBrusher.Util.Implementation.Filter;
using ByteBrusher.Util.Implementation.Scan;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace ByteBrusher.Util.Unittest.Filter;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "CA1707:Identifiers should not contain underscores", Justification = "Allowed for unit tests for clarity")]
public class FilterUtilTest
{
    private Mock<ILogger<ScanUtil>> _mockLogger = null!;
    private Mock<IOptions<FileExtensions>> _mockOptions= null!;
    private Mock<ICliOptions> _mockCliOptions= null!;
    private FilterUtil _filterUtil= null!;

    [SetUp]
    public void Setup()
    {
        _mockLogger = new Mock<ILogger<ScanUtil>>();
        _mockOptions = new Mock<IOptions<FileExtensions>>();
        _mockCliOptions = new Mock<ICliOptions>();

        _filterUtil = new FilterUtil(_mockLogger.Object, _mockOptions.Object, _mockCliOptions.Object);
    }

    [Test]
    public void FilterFiles_WhenCalled_FiltersFilesBasedOnCliOptions()
    {
        // Arrange
        var files = new List<FoundFile>
        {
            new() { FileType = new Video() },
            new() { FileType = new Document() }
        };

        _mockCliOptions.Setup(o => o.IncludeVideos).Returns(true);
        _mockCliOptions.Setup(o => o.IncludeDocuments).Returns(false);

        // Act
        List<FoundFile> result = _filterUtil.FilterFiles(files);

        // Assert
        Assert.That(result, Has.Exactly(1).Matches<FoundFile>(file => file.GetType() == typeof(Video)));
    }

    [Test]
    public void IncludeFile_ShouldReturnTrueForVideoWhenVideosAreIncluded()
    {
        var file = new FoundFile { FileType = new Video() };
        _mockCliOptions.Setup(o => o.IncludeVideos).Returns(true);

        bool result = _filterUtil.IncludeFile(file);

        Assert.IsTrue(result);
    }

    [Test]
    public void IncludeFile_WhenCalled_ReturnsTrueForIncludedFileType()
    {
        // Arrange
        var file = new FoundFile { FileType = new Video() };
        _mockCliOptions.Setup(o => o.IncludeVideos).Returns(true);

        // Act
        bool result = _filterUtil.IncludeFile(file);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IncludeFile_WhenCalled_ReturnsFalseForExcludedFileType()
    {
        // Arrange
        var file = new FoundFile { FileType = new Document() };
        _mockCliOptions.Setup(o => o.IncludeDocuments).Returns(false);

        // Act
        bool result = _filterUtil.IncludeFile(file);

        // Assert
        Assert.IsFalse(result);
    }

}
