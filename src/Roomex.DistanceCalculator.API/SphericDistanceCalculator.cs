public class SphericDistanceCalculator: IDistanceCalculator {
    private const int radiusOfEarth  = 6371;
    private double latitude1;
    private double longtitude1;
    private double latitude2;
    private double longtitude2;
    

    public SphericDistanceCalculator(Location locationFrom, Location locationTo)
    {
        latitude1 = locationFrom.latitude;
        longtitude1 = locationFrom.longtitude;
        latitude2 = locationTo.latitude;
        longtitude2 = locationTo.longtitude;
    }
    public double Execute(){
        var φ1 = latitude1 * Math.PI/180;
        var φ2 = latitude2 * Math.PI/180;
        var Δφ = (latitude2 - latitude1) * Math.PI/180;
        var Δλ = (longtitude2 - longtitude1) * Math.PI/180;

        var a = Math.Sin(Δφ/2) * Math.Sin(Δφ/2) +
                Math.Cos(φ1) * Math.Cos(φ2) *
                Math.Sin(Δλ/2) * Math.Sin(Δλ/2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));

        var distance = radiusOfEarth * c;
        return distance;
    }
}

