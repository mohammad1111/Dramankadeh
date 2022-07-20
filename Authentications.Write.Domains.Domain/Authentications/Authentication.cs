using Authentications.Write.Domains.Domain.Authentications.Events;
using Darmankadeh.Core.Domain;

namespace Authentications.Write.Domains.Domain.Authentications;

public class Authentication : AggregateRoot
{
    private Authentication()
    {
    }

    public Authentication(string emailAddress, string mobile) : base(Guid.NewGuid())
    {
        SetEmail(emailAddress);
        SetMobileNumber(mobile);
        AddEvent(new AuthenticationCreatedEvent(Id,mobile,emailAddress));
    }


    public EmailAddress EmailAddress { get; private set; }
    public MobileNumber MobileNumber { get; private set; }

    private void SetMobileNumber(string mobileNumber)
    {
        MobileNumber = new MobileNumber(mobileNumber);
    }

    private void SetEmail(string emailAddress)
    {
        EmailAddress = new EmailAddress(emailAddress);
    }

    public void Remove()
    {
        AddEvent(new AuthenticationRemovedEvent(Id));
        
    }
}