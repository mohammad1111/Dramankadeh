using Dramankadeh.Core.EventBus;

namespace Darmankadeh.Core.Domain;

public interface IAggregateRoot
{
    List<DomainEvent> Changes { get; set; }
}