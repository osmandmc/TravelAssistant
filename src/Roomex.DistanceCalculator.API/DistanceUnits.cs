public class DistanceUnits{
    public static readonly Dictionary<string, MeasurmentUnit> Dictionary = 
        new Dictionary<string, MeasurmentUnit>{
            { "en-US", MeasurmentUnit.Mile },
            { "en-GB", MeasurmentUnit.KM },
            { "de-DE", MeasurmentUnit.KM },
            { "fr-FR", MeasurmentUnit.KM },
        };

}