using Dramankadeh.Core.EventBus;

namespace Dramankadeh.ShareProjects.ShareModel.CreateUserEvents;

public class UserNeedAuthenticationEvent:IIntegrationMessage
{
    public Guid CorrelationEventId { get; set; }
    
    public string Email { get; set; }

    public string Mobile { get; set; }
    
    public string Firstname { get; set; }
    
    public string Lastname { get; set; }
    
    public string Address { get; set; }
}