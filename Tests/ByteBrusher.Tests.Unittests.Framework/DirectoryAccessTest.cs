using ByteBrusher.Framework.Implementation.Access;
using ByteBrusher.Tests.Util;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBrusher.Tests.Unittests.Framework;

public class DirectoryAccessTest
{
    private DirectoryAccess _directoryAccess = null!;
    private TemporaryDirectory _temporaryDirectory = null!;

    [SetUp]
    public void Setup()
    {
        _directoryAccess = new DirectoryAccess();
        _temporaryDirectory = TemporaryDirectory.Create();
    }

    [Test]
    public void GetFiles_WhenDirectoryNotEmpty_returnFiles()
    {
        // Arrange
        File.Create(Path.Combine(_temporaryDirectory.DirectoryPath, "test.txt")).Close();
        File.Create(Path.Combine(_temporaryDirectory.DirectoryPath, "test2.txt")).Close();

        // var expected = new List<string> { "test.txt", "test2.txt" };
        // Act
        List<string> result = _directoryAccess.GetFilesInPath(_temporaryDirectory.DirectoryPath);

        // Assert
        result.Should().HaveCount(2);
    }

    [Test]
    public void GetFiles_WhenDirectoryEmpty_returnEmptyList()
    {
        // Arrange
        // Act
        List<string> result = _directoryAccess.GetFilesInPath(_temporaryDirectory.DirectoryPath);

        // Assert
        result.Should().BeEmpty();
    }

    [TearDown]
    public void TearDown() => _temporaryDirectory.Dispose();
}
