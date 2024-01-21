namespace ByteBrusher.Core.Exceptions;

internal sealed class FileTypeNotSpecifiedException : System.Exception
{
    public FileTypeNotSpecifiedException(string message)
        : base(message)
    {}

    public FileTypeNotSpecifiedException(string message, Exception inner)
        : base(message, inner)
    {}
}
