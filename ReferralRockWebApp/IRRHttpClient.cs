public interface IRRHttpClient
{
    Task<T?> Get<T>(string endpoint);
}