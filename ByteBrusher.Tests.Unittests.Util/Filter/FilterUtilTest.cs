using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Core.File.FileTypes.Abstraction;
using ByteBrusher.Core.IOptions;
using ByteBrusher.Core.Parameter;
using ByteBrusher.Util.Implementation.Filter;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace ByteBrusher.Tests.Unittests.Util.Filter;

public class FilterUtilTest
{
    private Mock<ILogger<FilterUtil>> _mockLogger = null!;
    private Mock<IOptions<FileExtensions>> _mockOptions= null!;
    private ByteBrusherParams _mockParams= null!;
    private FilterUtil _filterUtil= null!;

    [SetUp]
    public void Setup()
    {
        _mockLogger = new Mock<ILogger<FilterUtil>>();
        _mockOptions = new Mock<IOptions<FileExtensions>>();
        _mockParams = new ByteBrusherParams();

        _mockParams = new ByteBrusherParams
        {
            Path = "/example/path",
            DeleteFlag = true,
            IncludeVideos = true,
            IncludeDocuments = true
        };

        _filterUtil = new FilterUtil(_mockLogger.Object);
    }

    [Test]
    public void FilterFiles_WhenCalled_ShouldReturnFilteredFiles()
    {
        // Arrange
        var listToFilter = new List<FoundFile>
        {
            new()
            {
                FileType = new Mock<IFileType>().Object,
                FileInfo =  new FileInfo("test.txt"),
                GotDeleted = false
            },
            new()
            {
                FileType = new Mock<IFileType>().Object,
                FileInfo =  new FileInfo("test.txt"),
                GotDeleted = false
            },
        };

        // Act
        List<FoundFile> result = _filterUtil.FilterFiles(listToFilter, new ByteBrusherParams());

        // Assert
        // Hier fügen Sie Ihre Assertions hinzu, z.B.:
        result.Should().HaveCount(0);
        // Weitere Überprüfungen basierend auf Ihrer Geschäftslogik
    }


    [Test]
    public void IncludeFile_WhenCalled_ReturnsFalseForExcludedFileType()
    {
        // Arrange
        var file = new FoundFile { FileType = new Document() };
        _mockParams.IncludeDocuments = false;

        // Act
        bool result = _filterUtil.IncludeFile(file, new ByteBrusherParams());

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    [TestCase(typeof(Video), true)]
    [TestCase(typeof(Document), true)]
    public void IncludeFile_WhenCalled_ReturnsFalseForExcludedFileType(Type type, bool include)
    {
        // Arrange
        var file = new FoundFile { FileType = (IFileType)Activator.CreateInstance(type)! };
        _mockParams.IncludeVideos = include;

        // Act
        bool result = _filterUtil.IncludeFile(file, new ByteBrusherParams());

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void FoundFile_Initialization_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var mockFileType = new Mock<IFileType>(); // Mock für IFileType
        var testFileInfo = new FileInfo("test.txt"); // Erstellen einer FileInfo-Instanz

        // Act
        var foundFile = new FoundFile
        {
            FileType = mockFileType.Object,
            FileInfo = testFileInfo,
            GotDeleted = false
        };

        // Assert
        foundFile.FileType.Should().BeSameAs(mockFileType.Object, "because FileType should be set correctly");
        foundFile.FileInfo.Should().BeEquivalentTo(testFileInfo, "because FileInfo should be set correctly");
        foundFile.GotDeleted.Should().BeFalse("because GotDeleted should be initialized as false");
    }
}
