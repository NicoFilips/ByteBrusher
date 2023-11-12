using ByteBrusher.Core.File;
using ByteBrusher.Util.Abstraction.Hash.Models;
using ByteBrusher.Util.Implementation.Delete;
using ErrorOr;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ByteBrusher.Util.Unittest.Delete;

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
        Assert.IsTrue(result.IsError);
        Assert.That(result.FirstError.Description, Is.EqualTo("No duplicates found"));
    }
}
