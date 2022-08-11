public class SphericDistanceCalculator: IDistanceCalculator {
    private Location locationFrom;
    private Location locationTo;

    public SphericDistanceCalculator(Location locationFrom, Location locationTo)
    {
        this.locationFrom = locationFrom;
        this.locationTo = locationTo;
    }
    public double Execute(){
        
        return double.MinValue;
    }
}

