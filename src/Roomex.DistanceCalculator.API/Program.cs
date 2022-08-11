var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/", () => 
    {
        return "Hello";
    }
);

app.MapGet("/api/v1/Distance/Calculate", (double xCoordinate, double yCoordinate, short calculationType) => 
    {
        var location1 = Location.Create(xCoordinate, yCoordinate);
        var location2 = Location.Create(xCoordinate, yCoordinate);
        IDistanceCalculator distanceCalculator = DistanceCalculatorFactory.Create(calculationType, location1, location2);
        var distance = distanceCalculator.Execute();
        return distance;
    }
);

app.Run();

 public partial class Program { }