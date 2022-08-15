public class PythagorasDistanceCalculator: IDistanceCalculator{
    private const int radiusOfEarth  = 6371;
     private double latitude1;
    private double longtitude1;
    private double latitude2;
    private double longtitude2;
    

    public PythagorasDistanceCalculator(Location locationFrom, Location locationTo)
    {
        latitude1 = locationFrom.latitude;
        longtitude1 = locationFrom.longtitude;
        latitude2 = locationTo.latitude;
        longtitude2 = locationTo.longtitude;
    }
    public double Execute(){
        var distance = 
            radiusOfEarth * 
            Math.Sqrt(
                Math.Pow(latitude1 - latitude2, 2) + 
                Math.Pow(longtitude1 - longtitude2, 2)
            ) * 
            Math.PI / 180;
        return distance;
    }
}