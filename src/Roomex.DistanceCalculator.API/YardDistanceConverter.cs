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
