using ErrorOr;
using MediatR;
using MilesCarRental.Domain.Entities.Cars;
using MilesCarRental.Domain.Primitives;

namespace MilesCarRental.Core.Modules.Cars.Create;

internal sealed class CreateCarCommandHandler : 
    IRequestHandler<CreateCarCommand, ErrorOr<Unit>>
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCarCommandHandler(ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateCarCommand command, CancellationToken cancellationToken)
    {
        try
        {
            ////
            //Here you enter the validations that could trigger errors.

            var car = new Car(
                new CarId(Guid.NewGuid()),
                command.Brand,
                command.Model,
                command.Location,
                command.Type,
                command.State
            );

            _carRepository.Add(car);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception ex)
        {
            return Error.Failure("Create car failed: " + ex.Message);
        }
    }
}