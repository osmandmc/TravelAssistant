public class PythagorasDistanceCalculator: IDistanceCalculator{
    private Location locationFrom;
    private Location locationTo;

    public PythagorasDistanceCalculator(Location locationFrom, Location locationTo)
    {
        this.locationFrom = locationFrom;
        this.locationTo = locationTo;
    }
    public double Execute(){
        return double.MinValue;
    }
}