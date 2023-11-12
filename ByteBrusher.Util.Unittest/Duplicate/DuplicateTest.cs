using ByteBrusher.Util.Implementation.Duplicate;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ByteBrusher.Util.Unittest.Duplicate;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "CA1707:Identifiers should not contain underscores", Justification = "Allowed for unit tests for clarity")]
public class DuplicateTest
{
    private List<string> suffixes = null!;
    private List<string> files = null!;
    private Mock<ILogger<DuplicateUtil>> loggerMock = null!;
    private DuplicateUtil duplicateUtil = null!;

    [SetUp]
    public void Setup()
    {
        loggerMock = new Mock<ILogger<DuplicateUtil>>();
        duplicateUtil = new DuplicateUtil(loggerMock.Object);
        suffixes = new List<string> { ".jpg", ".png", ".txt" };
        files = new List<string> { "image.jpg", "document.txt", "video.mp4", "photo.png" };
    }

    [Test]
    public void Should_ReturnEmptyList_When_FilesDoNotContainSuffixes()
    {
        var filesWithoutSuffixes = new List<string> { "video.mp4", "audio.mp3" };
        List<string> sortedList;
        sortedList = duplicateUtil.SortFiles(filesWithoutSuffixes, suffixes);

        Assert.IsEmpty(sortedList);
    }

    [Test]
    public void Should_HandleEmptyFileList()
    {
        var emptyFiles = new List<string>();
        List<string> sortedList = duplicateUtil.SortFiles(emptyFiles, suffixes);

        Assert.IsEmpty(sortedList);
    }
}
