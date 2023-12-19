namespace ByteBrusher;

public interface IByteBrusherClient
{
    public Task<bool> ExecuteAsync(bool deleteFlag, string pathToCleanUp);
}
