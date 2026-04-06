using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Windmill.HttpClients.Abstract;
using Soenneker.Windmill.OpenApiClientUtil.Abstract;
using Soenneker.Windmill.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Windmill.OpenApiClientUtil;

///<inheritdoc cref="IWindmillOpenApiClientUtil"/>
public sealed class WindmillOpenApiClientUtil : IWindmillOpenApiClientUtil
{
    private readonly AsyncSingleton<WindmillOpenApiClient> _client;

    public WindmillOpenApiClientUtil(IWindmillOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<WindmillOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Windmill:ApiKey");
            string authHeaderValueTemplate = configuration["Windmill:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
