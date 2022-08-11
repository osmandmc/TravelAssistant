public class DistanceCalculatorFactory{
    
    public static IDistanceCalculator Create(short calculatorType, Location locationFrom, Location locationTo)
    {
        if(calculatorType == 1){
            return new SphericDistanceCalculator(locationFrom, locationTo);
        }
        if(calculatorType == 2){
            return new PythagorasDistanceCalculator(locationFrom, locationTo);
        }
        throw new Exception("Not a valid calculation request");
    }
}