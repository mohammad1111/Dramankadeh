namespace Dramankadeh.Core.EventBus;

public interface IEventRepository
{
    Task<bool> IsHandelEvent(Guid eventId, string type);

    Task SaveInBoxEvent(Guid domainEventId, string type);

    Task CompleteEvent(PublisherEvent @event);

    Task<List<PublisherEvent>> GetEvents();

    Task<PublisherEvent> GetEvent(Guid domainEventId);
}