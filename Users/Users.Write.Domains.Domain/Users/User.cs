using Darmankadeh.Core.Domain;
using Users.Write.Domains.Domain.Users.Events;
using Users.Write.Domains.Domain.Users.Events;

namespace Users.Write.Domains.Domain.Users;

public class User : AggregateRoot
{
    public Guid AuthenticationId { get; private set; }

    private User()
    {
    }

    public User(string firstname, string lastname,string address,Guid authenticationId) : base(Guid.NewGuid())
    {
        SetLastname(lastname);
        SetFirstname(firstname);
        SetAddress(address);
        SetAuthenticationId(authenticationId);
        AddEvent(new UsersCreatedEvent(Id,firstname,lastname,address,authenticationId));
    }


    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public string Address { get; private set; }

    private void SetAuthenticationId(Guid authenticationId)
    {
        AuthenticationId = authenticationId;
    }
    
    private void SetFirstname(string firstname)
    {
        Firstname = firstname;
    }
    private void SetLastname(string lastname)
    {
        Lastname = lastname;
    }

    private void SetAddress(string address)
    {
        Address = address;
    }


    public void Remove()
    {
        AddEvent(new UsersRemovedEvent(Id));
        
    }
}