using Domain.Core.Events;

namespace Domain.Products.Events;

public sealed record ProductCreatedDomainEvent(Product Product) : IDomainEvent;
