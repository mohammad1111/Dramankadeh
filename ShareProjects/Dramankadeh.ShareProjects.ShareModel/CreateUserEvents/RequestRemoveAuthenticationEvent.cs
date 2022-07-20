using Dramankadeh.Core.EventBus;

namespace Dramankadeh.ShareProjects.ShareModel.CreateUserEvents;

public class RequestRemoveAuthenticationEvent:IIntegrationMessage
{
    public Guid CorrelationEventId { get; set; }
    
    public string Email { get; set; }
    
    public Guid AuthenticationId { get; set; }

}