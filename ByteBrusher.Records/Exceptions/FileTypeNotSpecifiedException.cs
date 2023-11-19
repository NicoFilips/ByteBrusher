namespace ByteBrusher.Core.Exceptions;

internal sealed class FileTypeNotSpecified : Exception
{
    public FileTypeNotSpecified(string message)
        : base(message)
    {}
}
