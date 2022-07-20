namespace Dramankadeh.Core.EventBus;

public abstract class IntegrationMessage : IIntegrationMessage
{
    public Guid CorrelationEventId { get; set; } = Guid.NewGuid();
}