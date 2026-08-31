using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Windmill.HttpClients.Registrars;
using Soenneker.Windmill.OpenApiClientUtil.Abstract;

namespace Soenneker.Windmill.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the cached Windmill API client provider.
/// </summary>
public static class WindmillOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the Windmill API client provider as a singleton service.
    /// </summary>
    public static IServiceCollection AddWindmillOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddWindmillOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IWindmillOpenApiClientUtil, WindmillOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Windmill API client provider as a scoped service while retaining the singleton HTTP transport.
    /// </summary>
    public static IServiceCollection AddWindmillOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddWindmillOpenApiHttpClientAsSingleton()
                .TryAddScoped<IWindmillOpenApiClientUtil, WindmillOpenApiClientUtil>();

        return services;
    }
}
