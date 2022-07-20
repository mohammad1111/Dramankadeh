using Dramankadeh.Core.Helper;

namespace Dramankadeh.Core.EventBus;

public class EventAggregator : IEventBus
{
    private readonly IEnterpriseServiceBus _enterpriseServiceBus;
    private readonly List<object> _eventHandlerSubscribers;


    public EventAggregator(IEnterpriseServiceBus enterpriseServiceBus)
    {
        _eventHandlerSubscribers = new List<object>();

        _enterpriseServiceBus = enterpriseServiceBus;
    }

    public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
    {
        _eventHandlerSubscribers.Add(eventHandler);
    }

    public void Subscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent
    {
        _eventHandlerSubscribers.Add(action);
    }

    public void Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent
    {
        GigAsyncHelpers.RunSync(() => PublishAsync(eventToPublish));
    }

    public async Task PublishAsync<TEvent>(TEvent eventToPublish) where TEvent : IEvent
    {
        if (eventToPublish is IIntegrationMessage integrationMessage) await PublishExternalMessages(integrationMessage);

        await HandleEvent(eventToPublish);
    }


    private async Task HandleEvent<TEvent>(TEvent eventToPublish) where TEvent : IEvent
    {
        var eligibleSubscribers = GetEligibleSubscribers<TEvent>(eventToPublish);

        foreach (var eventHandler in eligibleSubscribers) await eventHandler.HandleAsync(eventToPublish);
    }

    private async Task PublishExternalMessages(IIntegrationMessage message)
    {
        await _enterpriseServiceBus.Publish(message);
    }


    private IEnumerable<IEventHandler<TEvent>> GetEligibleSubscribers<TEvent>(object eventToPublish)
        where TEvent : IEvent
    {
        var subscribers = _eventHandlerSubscribers.Where(s => s is IEventHandler<TEvent>)
            .OfType<IEventHandler<TEvent>>().ToList();


        return subscribers;
    }
}