public class Distance
{
    public MeasurmentUnit Unit { get; private set; }
    public double Value { get; private set; }

    public Distance(MeasurmentUnit measurmentUnit, double value)
    {
        Unit = measurmentUnit;
        Value = value;
    }
}

public enum MeasurmentUnit{
    KM = 1,
    Mile = 2,
    Yard = 3,
}


