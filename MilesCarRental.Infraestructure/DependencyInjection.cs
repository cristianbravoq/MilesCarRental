using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MilesCarRental.Core.Data;
using MilesCarRental.Domain.Primitives;
using MilesCarRental.Domain.Entities.Cars;
using MilesCarRental.Infraestructure.Persistence.Repositories;

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
            options.UseSqlServer(configuration.GetConnectionString("Database")));
        services.AddScoped<IApplicationDbContext>(sp => 
            sp.GetRequiredService<IApplicationDbContext>());
        services.AddScoped<IUnitOfWork>(sp => 
            sp.GetRequiredService<ApplicationDbContext>());
            
        services.AddScoped<ICarRepository, CarRepository>();

        return services;
    }
}