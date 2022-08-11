public class Location
{
    public double xCoordinate { get; private set; }
    public double yCoordinate { get; private set; }

    private Location(double xCoordinate, double yCoordinate){
        this.xCoordinate = xCoordinate;
        this.yCoordinate = yCoordinate;
    }

    public static Location Create(double xCoordinate, double yCoordinate){
        return new Location(xCoordinate, yCoordinate);
    }
}