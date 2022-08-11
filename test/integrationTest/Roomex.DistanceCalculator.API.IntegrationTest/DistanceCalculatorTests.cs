using Xunit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Roomex.DistanceCalculator.API.IntegrationTest;

public class DistanceCalculatorTests
{
    private readonly HttpClient httpClient;

    public DistanceCalculatorTests()
    {
        var waf = new WebApplicationFactory<Program>();
        httpClient = waf.CreateClient();
        
    }
    [Fact]
    public async Task Calculate_Distance_Event_Triggered()
    {
        var httpResult = await httpClient.GetAsync("/");
        var response = await httpResult.Content.ReadAsStringAsync();
        Assert.Equal("Hello", response);
    }
}