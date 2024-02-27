using MilesCarRental.API;
using MilesCarRental.API.Extensions;
using MilesCarRental.Core;
using MilesCarRental.Infraestructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation()
                    .AddInfraestructure(builder.Configuration)
                    .AddApplication();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.ApplyMigrations();
    }
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}