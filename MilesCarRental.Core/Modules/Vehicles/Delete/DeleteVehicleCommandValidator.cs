using FluentValidation;

namespace MilesCarRental.Core.Modules.Vehicles.Delete;

public class DeleteCarCommandValidator : AbstractValidator<DeleteVehiclesCommand>
{
    public DeleteCarCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}