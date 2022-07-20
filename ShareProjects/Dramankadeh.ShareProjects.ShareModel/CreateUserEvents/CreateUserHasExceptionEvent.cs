using Dramankadeh.Core.EventBus;

namespace Dramankadeh.ShareProjects.ShareModel.CreateUserEvents;

public class CreateUserHasExceptionEvent:IIntegrationMessage
{
    public Guid CorrelationEventId { get; set; }
    
    public string Email { get; set; }
}