using ByteBrusher.Util.Implementation.Duplicate;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ByteBrusher.Tests.Unittests.Util.Duplicate;

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
        suffixes = [".jpg", ".png", ".txt"];
        files = ["image.jpg", "document.txt", "video.mp4", "photo.png"];
    }

    [Test]
    public void Should_ReturnEmptyList_When_FilesDoNotContainSuffixes()
    {
        var filesWithoutSuffixes = new List<string> { "video.mp4", "audio.mp3" };
        List<string> sortedList;
        sortedList = duplicateUtil.SortFiles(filesWithoutSuffixes, suffixes);

        sortedList.Should().BeEmpty();
    }

    [Test]
    public void Should_HandleEmptyFileList()
    {
        var emptyFiles = new List<string>();
        List<string> sortedList = duplicateUtil.SortFiles(emptyFiles, suffixes);

        sortedList.Should().BeEmpty();
    }

    [Test]
    public void SortList_Should_ReturnEmptyList_When_NoFilesMatchSuffixes()
    {
        // Arrange
        var suffixes = new List<string> { "txt", "doc" };
        var files = new List<string> { "file1.jpg", "file2.png" };
        var expected = new List<string>();

        // Act
        List<string> result = duplicateUtil.SortList(suffixes, files);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void SortList_Should_ReturnFilesWithSpecifiedSuffixes()
    {
        // Arrange
        var suffixes = new List<string> { "txt", "doc" };
        var files = new List<string> { "file1.txt", "file2.jpg", "file3.doc", "file4.docx" };
        var expected = new List<string> { "file1.txt", "file3.doc" };

        // Act
        List<string> result = duplicateUtil.SortList(suffixes, files);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}
