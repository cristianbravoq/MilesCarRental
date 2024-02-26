using MilesCarRental.Core.Services.Contracts;
using MilesCarRental.Core.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<ICarService, CarService>();
    builder.Services.AddScoped<ILocationService, LocationService>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}