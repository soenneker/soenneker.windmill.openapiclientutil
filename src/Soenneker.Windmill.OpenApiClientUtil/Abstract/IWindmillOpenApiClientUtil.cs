using Soenneker.Windmill.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Windmill.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached Windmill API client backed by the configured HTTP transport.
/// </summary>
public interface IWindmillOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Windmill API client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured Windmill API client.</returns>
    ValueTask<WindmillOpenApiClient> Get(CancellationToken cancellationToken = default);
}
