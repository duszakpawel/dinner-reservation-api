namespace Demo.Service.Client
{
    public class BaseApiClient
    {
        protected async Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            // Przykładowa implementacja metody tworzącej żądanie HTTP
            var request = new HttpRequestMessage();

            // Tutaj możesz dodać niestandardowe nagłówki, tokeny, zawartość itp.
            await Task.CompletedTask;

            return request;
        }
    }
}
