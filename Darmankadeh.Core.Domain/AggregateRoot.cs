using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Dramankadeh.Core.EventBus;

namespace Darmankadeh.Core.Domain;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    [NotMapped] public List<DomainEvent> Changes { get; set; } = new();
    protected AggregateRoot()
    {
    }
    protected AggregateRoot(Guid  id)
    {
        Id = id;
    }

    public void AddEvents([NotNull] IEnumerable<DomainEvent> events)
    {
        foreach (var @event in events) AddEvent(@event);
    }

    public void AddEvent(DomainEvent @event)
    {
        if (@event is not null) Changes.Add(@event);
    }


    public void AddUniqueEvent(DomainEvent @event)
    {
        var oldEvent = Changes.FirstOrDefault(x => x.GetType() == @event.GetType());
        if (oldEvent is not null) Changes.Remove(oldEvent);
        AddEvent(@event);
    }
}