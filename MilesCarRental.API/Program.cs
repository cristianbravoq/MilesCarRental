using MilesCarRental.API;
using MilesCarRental.API.Extensions;
using MilesCarRental.Core;
using MilesCarRental.Infraestructure;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation()
                    .AddInfraestructure(builder.Configuration)
                    .AddCore();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();