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