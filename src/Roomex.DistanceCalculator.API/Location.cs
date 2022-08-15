public class Location
{
    public double latitude { get; private set; }
    public double longtitude { get; private set; }

    private Location(double latitude, double longtitude){
        this.latitude = latitude;
        this.longtitude = longtitude;
    }

    public static Location Create(double latitude, double longtitude){
        return new Location(latitude, longtitude);
    }

    public ValidationResult Validate(){
        var errors = new List<string>();
        if(latitude > 90)
            errors.Add($"Latitude: {latitude} can not be higher than 90");
        if(latitude < -90)
            errors.Add($"Latitude: {latitude} can not be lower than 90");
        if(longtitude > 180)
            errors.Add($"Longtitude: {longtitude} can not be higher than 180");
        if(longtitude < -180)
            errors.Add($"Longtitude: {longtitude} can not be lower than 180");
        if(errors.Any())
            return ValidationResult.Failure(errors);
        
        return ValidationResult.Successful();
    }

    public Distance Distance(Location locationEnd, CalculationType calculationType, MeasurmentUnit measurmentUnit){
        var distanceCalculator = DistanceCalculatorFactory.Create(calculationType, this, locationEnd);
        var result = distanceCalculator.Execute();
        if(measurmentUnit == MeasurmentUnit.KM)
            return new Distance(MeasurmentUnit.KM, Math.Round(result, 2));
        var distanceConverter = DistanceConverterFactory.Get(measurmentUnit);
        var converted = distanceConverter.Execute(result);
        return new Distance(measurmentUnit, Math.Round(converted, 2));
    }
}