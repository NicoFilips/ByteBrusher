namespace ByteBrusher.Core.Exceptions;

public class FileTypeNotSpecifiedException : Exception
{
    public FileTypeNotSpecifiedException()
    {}

    public FileTypeNotSpecifiedException(string message)
        : base(message)
    {}

    public FileTypeNotSpecifiedException(string message, Exception inner)
        : base(message, inner)
    {}
}
