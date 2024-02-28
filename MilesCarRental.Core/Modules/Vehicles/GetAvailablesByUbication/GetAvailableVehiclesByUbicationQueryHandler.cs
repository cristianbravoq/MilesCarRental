using System.IO.Compression;
using ErrorOr;
using MediatR;
using MilesCarRental.Core.Modules.Vehicles.Common;
using MilesCarRental.Domain.Entities.Vechicles;
using MilesCarRental.Domain.Enumerations;

namespace MilesCarRental.Core.Modules.Vehicles.GetById;

internal sealed class GetAvailableVehiclesByUbicationQueryHandler : IRequestHandler<GetAvailableVehiclesByUbicationQuery,ErrorOr<IReadOnlyList<VehiclesResponse>>>
{
    private readonly IVehicleRepository _vehiclesRepository;

    public GetAvailableVehiclesByUbicationQueryHandler(IVehicleRepository vehiclesRepository)
    {
        _vehiclesRepository = vehiclesRepository ?? throw new ArgumentNullException(nameof(vehiclesRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<VehiclesResponse>>> Handle(GetAvailableVehiclesByUbicationQuery query, CancellationToken cancellationToken)
    {
        var request = new VehiclesAvailablesByLocationRequest(
            query.locationSelectedId,
            query.LatitudeUser,
            query.LongitudeUser
        );

        if (await _vehiclesRepository.GetAvailableVehiclesByLocationAsync(request) is not List<Vehicle> vehicles)
        {
            return Error.NotFound("Vehicle.NotFound", "The vehicle with the provide Id was not found.");
        }

        return vehicles.Select(
            vehicle => new VehiclesResponse(
                vehicle.Id!.value,
                vehicle.Brand!,
                vehicle.Model!,
                (ClasificationVehicleType)vehicle.Type,
                (StateVehicleType)vehicle.State,
                vehicle.Location.Address,
                vehicle.Location.Latitude,
                vehicle.Location.Longitude
            )
        ).ToList();
    }
}