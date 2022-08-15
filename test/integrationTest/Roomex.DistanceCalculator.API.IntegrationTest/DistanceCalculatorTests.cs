using Xunit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using System;

namespace Roomex.DistanceCalculator.API.IntegrationTest;

public class DistanceCalculatorTests
{
    private readonly HttpClient httpClient;
    private readonly string GoogleMapsKMDistanceBetweenHomeAndRoomexOffice = "{\"unit\":1,\"value\":4.44}";
    private readonly string GoogleMapsMIDistanceBetweenHomeAndRoomexOffice =  "{\"unit\":2,\"value\":2.76}";
    public DistanceCalculatorTests()
    {
        var waf = new WebApplicationFactory<Program>();
        httpClient = waf.CreateClient();
    }
    [Fact]
    public async Task Hello()
    {
        var httpResult = await httpClient.GetAsync("/");
        var response = await httpResult.Content.ReadAsStringAsync();
        Assert.Equal("Hello", response);
    }
    [Fact]
    public async Task Given_Client_Is_In_UK_And_Location_From_Is_140LeeesonStreet_And_CityTo_Is_Roomex_When_Distance_Is_Calculated_Spheric_Then_Result_Is_Same_As_GoogleMap(){
        httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-GB");
        var httpResult = 
            await httpClient.GetAsync("/api/v1/Distance/Calculate?latitude1=53.33108183043875&longtitude1=-6.251925572960338&latitude2=53.29151355520144&longtitude2=-6.260372772961772&calculationType=1");
        var httpResponse = await httpResult.Content.ReadAsStringAsync();
        Assert.True(httpResult.IsSuccessStatusCode);
        Assert.Equal(GoogleMapsKMDistanceBetweenHomeAndRoomexOffice, httpResponse);
    }
    [Fact]
    public async Task Given_Client_Is_In_USA_And_Location_From_Is_140LeeesonStreet_And_CityTo_Is_Roomex_When_Distance_Is_Calculated_Spheric_Then_Result_Is_Same_As_GoogleMap(){
        httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US");
        var httpResult = 
            await httpClient.GetAsync("/api/v1/Distance/Calculate?latitude1=53.33108183043875&longtitude1=-6.251925572960338&latitude2=53.29151355520144&longtitude2=-6.260372772961772&calculationType=1");
        var httpResponse = await httpResult.Content.ReadAsStringAsync();
        Assert.True(httpResult.IsSuccessStatusCode);
        Assert.Equal(GoogleMapsMIDistanceBetweenHomeAndRoomexOffice, httpResponse);
    }
    [Fact]
    public async Task Given_Location_From_Latitude_Is_100_And_Longtitude_Is_200_When_Distance_Is_Calculated_Then_Result_Is_Invalid_Latitude_And_Longtitude(){
         var httpResult = 
            await httpClient.GetAsync("/api/v1/Distance/Calculate?latitude1=100&longtitude1=200&latitude2=53.29151355520144&longtitude2=-6.260372772961772&calculationType=1");
        var httpResponse = await httpResult.Content.ReadAsStringAsync();
        Assert.False(httpResult.IsSuccessStatusCode);
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, httpResult.StatusCode);
        Assert.Equal("{\"success\":false,\"errors\":[\"Latitude: 100 can not be higher than 90\",\"Longtitude: 200 can not be higher than 180\"]}"
, httpResponse);
    }
}