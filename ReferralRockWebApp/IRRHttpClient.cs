public interface IRRHttpClient
{
    Task<T?> Get<T>(string endpoint);
    Task<T?> Post<T, B>(string endpoint, B body);
    Task<T?> Delete<T, B>(string endpoint, B body);
}