using Soenneker.Windmill.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Windmill.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IWindmillOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<WindmillOpenApiClient> Get(CancellationToken cancellationToken = default);
}
