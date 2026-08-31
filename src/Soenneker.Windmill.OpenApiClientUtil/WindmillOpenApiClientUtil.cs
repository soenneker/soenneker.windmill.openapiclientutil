using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Windmill.HttpClients.Abstract;
using Soenneker.Windmill.OpenApiClientUtil.Abstract;
using Soenneker.Windmill.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Windmill.OpenApiClientUtil;

public sealed class WindmillOpenApiClientUtil : IWindmillOpenApiClientUtil
{
    private readonly AsyncSingleton<WindmillOpenApiClient> _client;

    public WindmillOpenApiClientUtil(IWindmillOpenApiHttpClient httpClientProvider)
    {
        _client = new AsyncSingleton<WindmillOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientProvider.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new WindmillOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<WindmillOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
