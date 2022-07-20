namespace Dramankadeh.Core.EventBus;

public interface IIntegrationMessage : IEvent
{
    Guid CorrelationEventId { get; set; }
}