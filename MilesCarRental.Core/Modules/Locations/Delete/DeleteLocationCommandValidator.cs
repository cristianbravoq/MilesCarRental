using FluentValidation;

namespace MilesCarRental.Core.Modules.Locations.Delete;

public class DeleteLocationCommandValidator : AbstractValidator<DeleteLocationCommand>
{
    public DeleteLocationCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}