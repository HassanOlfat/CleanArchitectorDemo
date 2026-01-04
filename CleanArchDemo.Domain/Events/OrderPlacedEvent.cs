namespace CleanArchDemo.Domain.Events;

public record OrderPlacedEvent(int OrderId, int CustomerId, DateTime PlacedAt);