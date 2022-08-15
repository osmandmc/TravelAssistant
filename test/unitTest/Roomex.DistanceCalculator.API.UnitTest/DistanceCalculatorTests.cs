using System.Collections.Generic;
using Xunit;

namespace Roomex.DistanceCalculator.API.UnitTest;

public class DistanceCalculatorTests
{

    public DistanceCalculatorTests()
    {
        
    }
    [Fact]
    public void Given_City_From_Is_A_And_CityTo_Is_B_When_Distance_Is_Calculated_Spheric_Then_Result_Is_As_Expected()
    {   
        var googleMapsKMDistanceBetweenHomeAndRoomexOffice = 4.44;
        var googleMapsMiDistanceBetweenHomeAndRoomexOffice = 2.76;
        //Arrange
        var locationFrom = Location.Create(53.33108183043875, -6.251925572960338);
        var locationTo = Location.Create(53.29151355520144, -6.260372772961772);
        var sphericDistanceCalculator = new SphericDistanceCalculator(locationFrom, locationTo);
        //Act
        var distanceKM = locationFrom.Distance(locationTo, CalculationType.Spheric, MeasurmentUnit.KM);
        var distanceMile = locationFrom.Distance(locationTo, CalculationType.Spheric, MeasurmentUnit.Mile);
        //Assert
        Assert.Equal(distanceKM.Value, googleMapsKMDistanceBetweenHomeAndRoomexOffice);
        Assert.Equal(distanceMile.Value, googleMapsMiDistanceBetweenHomeAndRoomexOffice);
    }
    [Fact]
    public void Given_City_From_Is_A_And_CityTo_Is_B_When_Distance_Is_Calculated_With_Pythagoras_Then_Result_Is_As_Expected()
    {   
        //Arrange
        var locationFrom = Location.Create(53.33108183043875, -6.251925572960338);
        var locationTo = Location.Create(53.29151355520144, -6.260372772961772);
        //Act
        var distance1 = locationFrom.Distance(locationTo, CalculationType.Pythagoraen, MeasurmentUnit.KM);
        var distance2 = locationTo.Distance(locationFrom, CalculationType.Pythagoraen, MeasurmentUnit.KM);
        //Assert
        Assert.Equal(distance1.Value, distance2.Value);
    }

    [Fact]
    public void Given_Location_From_Latitude_Is_100_And_Longtitude_Is_200_When_Distance_Is_Calculated_Then_Result_Is_Invalid_Latitude_And_Longtitude()
    {   
        //Arrange
        var locationFrom = Location.Create(100, 200);
        var locationTo = Location.Create(53.29151355520144, -6.260372772961772);

        //Act
        var validation = locationFrom.Validate();
        //Assert
        Assert.Equal(validation.Errors, new List<string>{"Latitude: 100 can not be higher than 90", "Longtitude: 200 can not be higher than 180"});
    }
} 