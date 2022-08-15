public class DistanceCalculatorFactory{
    
    public static IDistanceCalculator Create(CalculationType calculatorType, Location locationFrom, Location locationTo)
    {
        if(calculatorType == CalculationType.Spheric){
            return new SphericDistanceCalculator(locationFrom, locationTo);
        }
        if(calculatorType == CalculationType.Pythagoraen){
            return new PythagorasDistanceCalculator(locationFrom, locationTo);
        }
        throw new Exception("Not a valid calculation request");
    }
}

public enum CalculationType{
    Spheric = 1,
    Pythagoraen = 2
}