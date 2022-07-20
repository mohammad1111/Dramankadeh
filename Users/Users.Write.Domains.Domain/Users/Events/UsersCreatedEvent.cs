using Dramankadeh.Core.EventBus;

namespace Users.Write.Domains.Domain.Users.Events;

public class UsersCreatedEvent : DomainEvent
{
    public UsersCreatedEvent(Guid usersId, string firstname, string lastname, string address, Guid authenticationId)
    {
        Firstname = firstname;
        Lastname = lastname;
        Address = address;
        AuthenticationId = authenticationId;
        UsersId = usersId;
    }

    public string Firstname { get; }
    public string Lastname { get; }
    public string Address { get; }
    public Guid AuthenticationId { get; }

    public Guid UsersId { get; }
}