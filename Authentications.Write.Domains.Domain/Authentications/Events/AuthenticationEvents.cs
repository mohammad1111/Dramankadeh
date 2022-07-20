using Dramankadeh.Core.EventBus;

namespace Authentications.Write.Domains.Domain.Authentications.Events;

public class AuthenticationCreatedEvent : DomainEvent
{
    public AuthenticationCreatedEvent(Guid authenticationId, string mobileNumber, string emailAddress)
    {
        AuthenticationId = authenticationId;
        MobileNumber = mobileNumber;
        EmailAddress = emailAddress;
    }

    public Guid AuthenticationId { get; }
    public string MobileNumber { get; }
    public string EmailAddress { get; }
}