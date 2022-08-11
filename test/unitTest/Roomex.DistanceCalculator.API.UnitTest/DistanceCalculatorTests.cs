using Xunit;

namespace Roomex.DistanceCalculator.API.UnitTest;

public class DistanceCalculatorTests
{
    [Fact]
    public void Given_City_From_Is_A_And_CityTo_Is_B_When_Distance_Is_Calculated_Then_Result_Is_As_Expected()
    {   
        //Arrange
        var locationFrom = Location.Create(213123, 1341231);
        var locationTo = Location.Create(213123, 1341231);

        var sphericDistanceCalculator = new SphericDistanceCalculator(locationFrom, locationTo);

        //Act
        var result = sphericDistanceCalculator.Execute();

        //Assert
        Assert.Equal(result, double.MinValue);
    }
} 