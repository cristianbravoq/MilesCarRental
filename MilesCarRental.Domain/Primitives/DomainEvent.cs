using MediatR;

namespace MilesCarRental.Domain.Primitives;

public record DomainEvent(Guid Id) : INotification;