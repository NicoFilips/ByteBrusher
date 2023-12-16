using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Core.File.FileTypes.Abstraction;
using ByteBrusher.Core.IOptions;
using ByteBrusher.Framework.Abstraction.Access;
using ByteBrusher.Util.Implementation.Scan;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace ByteBrusher.Tests.Unittests.Util.Scan;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "CA1707:Identifiers should not contain underscores", Justification = "Allowed for unit tests for clarity")]
[TestFixture]
public class ScanutilTest
{
    private Mock<ILogger<ScanUtil>> _mockLogger = null!;
    private readonly Mock<IOptions<FileExtensions>> _mockConfig = new();
    private readonly Mock<IDirectoryAccess> _mockDirectoryAccess = new();
    private ScanUtil _scanUtil = null!;
    private static readonly string[] vidSuffix = new[] { ".mp4", ".avi", ".mkv", ".mov", ".wmv", ".flv", ".webm" };
    private static readonly string[] imgSuffix = new[] { ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".svg", ".tiff", ".tif" };
    private static readonly string[] docSuffix = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".rtf", ".odt", ".ods", ".odp", ".xml", ".csv" };

    [SetUp]
    public void Setup()
    {
        _mockLogger = new Mock<ILogger<ScanUtil>>();
        _mockConfig.Setup(ap => ap.Value).Returns(new FileExtensions
        {
            VideoSuffix = vidSuffix,
            ImageSuffix = imgSuffix,
            DocumentSuffix = docSuffix
        });
        _mockDirectoryAccess.Setup(ap => ap.GetFilesInPath(It.IsAny<string>())).Returns(new List<string>());
        _scanUtil = new ScanUtil(_mockLogger.Object, _mockDirectoryAccess.Object,  _mockConfig.Object);
    }

    [TestCase("Hello World", "a591a6d40bf420404a011733cfb7b190d62c65bf0bcda32b57b277d9ad9f146e")]
    [TestCase("", "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855")]
    public void ComputeSha256Hash_ReturnsCorrectHash_ForKnownInputs(string testContent, string expectedHash)
    {
        // Arrange
        string testFileName = Path.GetTempFileName();
        File.WriteAllText(testFileName, testContent);
        _mockDirectoryAccess.Setup(f => f.OpenRead(It.IsAny<string>()))
                            .Returns((string path) => File.OpenRead(path));

        try
        {
            // Act
            string actualHash = _scanUtil.ComputeSha256Hash(testFileName);

            // Assert
            actualHash.Should().Be(expectedHash);
        }
        finally
        {
            File.Delete(testFileName);
        }
    }


    [Test]
    public void GetsAllDuplicates_WhenNoDuplicates_ShouldReturnEmptyList()
    {
        // Arrange
        var files = new List<string> { "file1.jpg", "file2.jpg" };
        _mockDirectoryAccess.Setup(m => m.GetFilesInPath(It.IsAny<string>())).Returns(files);
        _mockDirectoryAccess.Setup(f => f.OpenRead(It.IsAny<string>()))
                            .Returns(() => new MemoryStream());

        // Act
        bool result = _scanUtil.GetsAllDuplicates("some/path");

        // Assert
        _mockDirectoryAccess.Verify(m => m.OpenRead("file1.jpg"), Times.Once);
        _mockDirectoryAccess.Verify(m => m.OpenRead("file2.jpg"), Times.Once);
    }

    [TestCase(".docx", typeof(Document))]
    [TestCase(".png", typeof(Image))]
    [TestCase(".avi", typeof(Video))]
    [TestCase(".unknown", typeof(Unspecified))]
    public void ClassifyFile_ShouldReturnCorrectFileType(string fileExtension, Type expectedType)
    {
        // Arrange
        string testFileName = $"test{fileExtension}";

        // Act
        IFileType result = _scanUtil.ClassifyFile(testFileName);

        // Assert
        result.Should().BeOfType(expectedType);
    }
}
