using Soenneker.Windmill.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Windmill.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class WindmillOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IWindmillOpenApiClientUtil _openapiclientutil;

    public WindmillOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IWindmillOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
