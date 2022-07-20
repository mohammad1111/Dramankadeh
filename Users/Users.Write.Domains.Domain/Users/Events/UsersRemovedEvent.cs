using Dramankadeh.Core.EventBus;

namespace Users.Write.Domains.Domain.Users.Events;

public class UsersRemovedEvent : DomainEvent
{
    public UsersRemovedEvent(Guid usersId)
    {
        UsersId = usersId;
  
    }

    public Guid UsersId { get; }

}