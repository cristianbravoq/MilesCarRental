using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MilesCarRental.Core.Data;
using MilesCarRental.Domain.Primitives;
using MilesCarRental.Domain.Entities.Vechicles;
using MilesCarRental.Infraestructure.Persistence.Repositories;
using MilesCarRental.Domain.Entities.Locations;
using NetTopologySuite.Geometries;

namespace MilesCarRental.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(
                configuration.GetConnectionString("SqlServer"),
                sqlServerOptions => sqlServerOptions.UseNetTopologySuite()
                ));
        services.AddScoped<IApplicationDbContext>(sp => 
            sp.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IUnitOfWork>(sp => 
            sp.GetRequiredService<ApplicationDbContext>());
            
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();

        services.AddScoped(provider =>
        {
            var geometryFactory = provider.GetRequiredService<GeometryFactory>();
            return geometryFactory;
        });

        return services;
    }
}