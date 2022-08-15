public interface IDistanceConverter{
    double Execute(double value);
}
public class MileDistanceConverter: IDistanceConverter
{
    public MeasurmentUnit Unit { get; private set; }
    public MileDistanceConverter(MeasurmentUnit unit)
    {
        Unit = unit;
    }
    public double Execute(double value){
        return value * 0.621371;
    }
}
public class YardDistanceConverter: IDistanceConverter
{
    public MeasurmentUnit Unit { get; private set; }
    public YardDistanceConverter(MeasurmentUnit unit)
    {
        Unit = unit;
    }
    public double Execute(double value){
        return value * 1093.61;
    }

}
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