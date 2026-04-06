using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Windmill.HttpClients.Registrars;
using Soenneker.Windmill.OpenApiClientUtil.Abstract;

namespace Soenneker.Windmill.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class WindmillOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="WindmillOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddWindmillOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddWindmillOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IWindmillOpenApiClientUtil, WindmillOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="WindmillOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddWindmillOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddWindmillOpenApiHttpClientAsSingleton()
                .TryAddScoped<IWindmillOpenApiClientUtil, WindmillOpenApiClientUtil>();

        return services;
    }
}
