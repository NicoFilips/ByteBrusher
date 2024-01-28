namespace ByteBrusher.Core.Exceptions;

public sealed class FileTypeNotSpecifiedException : System.Exception
{
    public FileTypeNotSpecifiedException(string message)
        : base(message)
    {}

    public FileTypeNotSpecifiedException(string message, Exception inner)
        : base(message, inner)
    {}
}
