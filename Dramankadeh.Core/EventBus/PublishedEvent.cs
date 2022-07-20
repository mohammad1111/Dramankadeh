namespace Dramankadeh.Core.EventBus;

public class PublishedEvent : PublishEvent
{
    public PublishedEvent(PublisherEvent publisher)
    {
        UpdateDateTime = DateTime.Now;
    }


    public DateTime UpdateDateTime { get; }
}