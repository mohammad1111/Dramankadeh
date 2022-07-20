using Dramankadeh.Core.EventBus;

// ReSharper disable once CheckNamespace
namespace Authentications.Write.Domains.Domain.Authentications.Events;

public class AuthenticationRemovedEvent : DomainEvent
{
    public AuthenticationRemovedEvent(Guid authenticationId)
    {
        AuthenticationId = authenticationId;
  
    }

    public Guid AuthenticationId { get; }

}