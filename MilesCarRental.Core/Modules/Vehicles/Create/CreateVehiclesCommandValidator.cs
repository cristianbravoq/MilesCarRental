using FluentValidation;

namespace MilesCarRental.Core.Modules.Vehicles.Create;

public class CreateVehiclesCommandValidator : AbstractValidator<CreateVehiclesCommand>
{
    public CreateVehiclesCommandValidator()
    {
        RuleFor(r => r.Brand)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(r => r.Model)
             .NotEmpty()
             .MaximumLength(5);

        RuleFor(r => r.State)
             .NotEmpty();

        RuleFor(r => r.Type)
            .NotEmpty();
    }
}