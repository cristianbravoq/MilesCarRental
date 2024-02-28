using System.IO.Compression;
using ErrorOr;
using MediatR;
using MilesCarRental.Core.Modules.Vehicles.Common;
using MilesCarRental.Domain.DomainErrors;
using MilesCarRental.Domain.Entities.Vechicles;
using MilesCarRental.Domain.Enumerations;
using MilesCarRental.Domain.ValueObjects;

namespace MilesCarRental.Core.Modules.Vehicles.GetById;

internal sealed class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, ErrorOr<VehiclesResponse>>
{
    private readonly IVehicleRepository _vehiclesRepository;

    public GetVehicleByIdQueryHandler(IVehicleRepository vehiclesRepository)
    {
        _vehiclesRepository = vehiclesRepository ?? throw new ArgumentNullException(nameof(vehiclesRepository));
    }

    public async Task<ErrorOr<VehiclesResponse>> Handle(GetVehicleByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _vehiclesRepository.GetByIdAsync(new VehicleId(query.Id)) is not Domain.Entities.Vechicles.Vehicle vehicle)
        {
            return Error.NotFound("Vehicle.NotFound", "The vehicle with the provide Id was not found.");
        }

        if (vehicle.Location == null)
        {
            return Error.NotFound("Location.NotFound", "The location of the vehicle is not found.");
        }

        if (Address.Create(vehicle.Location.Address.Country, vehicle.Location.Address.Line1, vehicle.Location.Address.Line2, vehicle.Location.Address.City,
                    vehicle.Location.Address.State, vehicle.Location.Address.ZipCode) is not Address address)
        {
          return ErrorsLocation.AddressWithBadFormat;
        }

        return new VehiclesResponse(
                vehicle.Id!.value,
                vehicle.Brand!,
                vehicle.Model!,
                (ClasificationVehicleType)vehicle.Type,
                (StateVehicleType)vehicle.State,
                address,
                vehicle.Location.Latitude,
                vehicle.Location.Longitude
            );
    }
}