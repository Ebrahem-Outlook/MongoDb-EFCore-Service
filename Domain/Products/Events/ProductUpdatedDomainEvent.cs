using Domain.Core.Events;

namespace Domain.Products.Events;

public sealed record ProductUpdatedDomainEvent(Product Product) : IDomainEvent;
