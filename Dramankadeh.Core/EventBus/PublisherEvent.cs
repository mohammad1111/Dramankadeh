using Dramankadeh.Core.Serilizer;

namespace Dramankadeh.Core.EventBus;

public class PublisherEvent : PublishEvent
{
    public PublisherEvent(Guid domainEventId, string entityName, string eventContent,
        string eventTypeString, DateTime createDateTime)
    {
        DomainEventId = domainEventId;
        EntityName = entityName;
        EventContent = eventContent;
        EventTypeString = eventTypeString;
        CreateDateTime = createDateTime;
    }

    public PublisherEvent(IEvent eventContent, string eventTypeString, string entityName, ISerializer serializer)
    {
        Object = eventContent;
        EventContent = serializer.Serialize(eventContent);
        EventTypeString = eventTypeString;
        EntityName = entityName;
        DomainEventId = Guid.NewGuid();
    }

    public IEvent Object { get; set; }


    public DateTime CreateDateTime { get; set; }


    public dynamic Deserialize(ISerializer serializer)
    {
        var method = typeof(ISerializer).GetMethod(nameof(serializer.Deserialize));
        var generic = method?.MakeGenericMethod(EventType);
        return generic?.Invoke(serializer, new object[] { EventContent });
    }
}