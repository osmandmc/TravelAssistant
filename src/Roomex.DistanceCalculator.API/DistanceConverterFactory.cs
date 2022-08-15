public class DistanceConverterFactory
{
    public static IDistanceConverter Get(MeasurmentUnit toUnit){
        if(toUnit == MeasurmentUnit.Mile)
            return new MileDistanceConverter(toUnit);
        if(toUnit == MeasurmentUnit.Yard)
            return new YardDistanceConverter(toUnit);
        throw new NotImplementedException("Not implemented converted");
    }

}