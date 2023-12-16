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
    public void OpenRead_WhenFileExists_ReturnsReadableStream()
    {
        // Arrange
        string tempFile = Path.GetTempFileName();
        try
        {
            // Erstellen einer Testdatei
            File.WriteAllText(tempFile, "Test content");

            // Act
            Stream stream = _directoryAccess.OpenRead(tempFile);

            // Assert
            Assert.That(stream, Is.Not.Null);
            Assert.That(stream.CanRead, Is.True);

            // Optional: Lesen des Streams, um zu überprüfen, ob der Inhalt korrekt ist
            using var reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            Assert.That(content, Is.EqualTo("Test content"));
        }
        finally
        {
            File.Delete(tempFile);
        }
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
