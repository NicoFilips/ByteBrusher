namespace ByteBrusher.Tests.Util;

public sealed record TemporaryDirectory : IDisposable
{
    public string DirectoryPath { get; }

    private TemporaryDirectory(string prefix = "_bytebrusher_unit_test")
    {
        DirectoryPath = Path.Combine(Path.GetTempPath(), CreateRandDirectoryName(prefix));
        Directory.CreateDirectory(DirectoryPath);
    }

    public static TemporaryDirectory Create(string prefix = "_bytebrusher_unit_test") => new(prefix);
    public static string CreateRandDirectoryName(string prefix) => string.Join("_", prefix, Path.GetRandomFileName());

    public void Dispose()
    {
        if (Directory.Exists(DirectoryPath))
            Directory.Delete(DirectoryPath, true);
    }
}
