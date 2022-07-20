namespace Dramankadeh.Core.EventBus;

public class DomainEvent : IIntegrationMessage
{
    public Guid CorrelationEventId { get; set; } = Guid.NewGuid();
}