var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/", () => 
    {
        return "Hello";
    }
);

app.MapGet("/api/v1/Distance/Calculate", (double latitude1, double longtitude1, double latitude2, double longtitude2, CalculationType calculationType, HttpContext context) => 
    {
        var unit = MeasurmentUnit.KM;
        var acceptedLanguages = context.Request.Headers.AcceptLanguage.ToString();
        var firstAcceptedLanguage = acceptedLanguages.Split(',').FirstOrDefault();
        if(firstAcceptedLanguage != null && 
            DistanceUnits.Dictionary.TryGetValue(firstAcceptedLanguage, out MeasurmentUnit requestUnit))
        {
            unit = requestUnit;
        }
        
        var locationStart = Location.Create(latitude1, longtitude1);
        var locationEnd = Location.Create(latitude2, longtitude2);
        
        var locationStartValidation = locationStart.Validate();
        var locationEndValidation = locationEnd.Validate();
        if(!locationStartValidation.Success || !locationEndValidation.Success){
            locationStartValidation.Combine(locationEndValidation);
            return Results.BadRequest(locationStartValidation);
        }

        var distance = locationStart.Distance(locationEnd, calculationType, unit);
        return Results.Ok(distance);
    }
);


app.Run();


public partial class Program { }