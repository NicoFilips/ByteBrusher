namespace ByteBrusher.Core.Exceptions;

public class FileTypeNotSpecifiedException : Exception
{
    public FileTypeNotSpecifiedException(string message)
        : base(message)
    {}
}
