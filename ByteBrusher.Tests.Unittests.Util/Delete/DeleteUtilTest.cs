using ByteBrusher.Core.File;
using ByteBrusher.Util.Abstraction.Hash.Models;
using ByteBrusher.Util.Implementation.Delete;
using ErrorOr;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ByteBrusher.Tests.Unittests.Util.Delete;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "CA1707:Identifiers should not contain underscores", Justification = "Allowed for unit tests for clarity")]
public class DeleteUtilTest
{
    private Mock<IFileAbstraction> fileAbstractionMock = new();
    private Mock<ILogger<DeleteUtil>> loggerMock = new();

    private DeleteUtil deleteUtil = null!;

    [SetUp]
    public void Setup()
    {
        loggerMock = new Mock<ILogger<DeleteUtil>>();
        fileAbstractionMock = new Mock<IFileAbstraction>();
        deleteUtil = new DeleteUtil(loggerMock.Object, fileAbstractionMock.Object);
    }


    [Test]
    public void TryDelete_ShouldReturnErrorWhenDuplicatesIsEmpty()
    {
        // Arrange
        var duplicates = new List<FoundFile>();

        // Act
        ErrorOr<Deleted> result = deleteUtil.TryDelete(duplicates);

        // Assert
        result.IsError.Should().BeTrue();
        Assert.That(result.FirstError.Code, Is.EqualTo("No duplicates found"));
    }

    [Test]
    public void TryDelete_ShouldReturnNotFoundErrorWhenFileDoesNotExist()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<DeleteUtil>>();
        var fileAbstractionMock = new Mock<IFileAbstraction>();
        var deleteUtil = new DeleteUtil(loggerMock.Object, fileAbstractionMock.Object);

        var nonExistentFile = new FoundFile { FileInfo = new FileInfo("nonexistentfile.txt") };
        var duplicates = new List<FoundFile> { nonExistentFile };

        fileAbstractionMock.Setup(fa => fa.Exists(nonExistentFile.FileInfo.FullName)).Returns(false);

        // Act
        ErrorOr<Deleted> result = deleteUtil.TryDelete(duplicates);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("One or more files do not exist");
    }
}
