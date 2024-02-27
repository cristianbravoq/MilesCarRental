using ErrorOr;
using MediatR;
using MilesCarRental.Domain.Enumerations;

namespace MilesCarRental.Core.Modules.Cars.Create;

public record CreateCarCommand(
    string Brand,
    string Model,
    string Location,
    ClasificationCarType Type,
    StateCarType State
): IRequest<ErrorOr<Unit>>;