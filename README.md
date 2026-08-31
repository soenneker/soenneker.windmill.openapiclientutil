[![](https://img.shields.io/nuget/v/soenneker.windmill.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.windmill.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.windmill.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.windmill.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.windmill.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.windmill.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.windmill.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.windmill.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Windmill.OpenApiClientUtil

Provides a cached `WindmillOpenApiClient` using the configured Windmill instance URL and bearer token.

## Installation

```bash
dotnet add package Soenneker.Windmill.OpenApiClientUtil
```

## Configuration

```json
{
  "Windmill": {
    "Token": "your-user-token",
    "ClientBaseUrl": "https://app.windmill.dev/api/"
  }
}
```

Use your own instance URL for self-hosted Windmill. `Windmill:ApiKey` remains supported as a legacy alias for `Token`.

## Registration and usage

```csharp
using Soenneker.Windmill.OpenApiClient.Models;
using Soenneker.Windmill.OpenApiClientUtil.Abstract;
using Soenneker.Windmill.OpenApiClientUtil.Registrars;

services.AddWindmillOpenApiClientUtilAsSingleton();

public sealed class WorkspaceService
{
    private readonly IWindmillOpenApiClientUtil _clientProvider;

    public WorkspaceService(IWindmillOpenApiClientUtil clientProvider)
    {
        _clientProvider = clientProvider;
    }

    public async Task<IReadOnlyList<ListWorkspaces200ResponseSchemaItem>> List(
        CancellationToken cancellationToken)
    {
        var client = await _clientProvider.Get(cancellationToken);
        return await client.Workspaces.List.GetAsync(
            cancellationToken: cancellationToken) ?? [];
    }
}
```

`AddWindmillOpenApiClientUtilAsScoped()` creates one generated client per scope while continuing to use the singleton HTTP transport. Disposing the scoped provider does not remove that shared transport.
