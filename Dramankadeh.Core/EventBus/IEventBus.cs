namespace Dramankadeh.Core.EventBus;

public interface IEventBus
{
    void Subscribe<T>(IEventHandler<T> handler) where T : IEvent;

    void Subscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent;

    void Publish<T>(T eventToPublish) where T : IEvent;

    Task PublishAsync<T>(T eventToPublish) where T : IEvent;
}

public interface ILocalEventBus
{
    Task PublishLocalMessageAsync<T>(T eventToPublish) where T : IEvent;
}