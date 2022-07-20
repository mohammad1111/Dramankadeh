namespace Dramankadeh.Core.EventBus;

public interface IEventHandler<T> where T : IEvent
{
    Task HandleAsync(T eventToHandle);
}