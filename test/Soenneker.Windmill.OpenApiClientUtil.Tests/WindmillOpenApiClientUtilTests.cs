using Soenneker.Windmill.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Windmill.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class WindmillOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IWindmillOpenApiClientUtil _openapiclientutil;

    public WindmillOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IWindmillOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
