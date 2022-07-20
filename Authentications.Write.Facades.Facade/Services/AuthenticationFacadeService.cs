extern alias DomainRefrence; 
using Authentications.Write.Applications.Application.Contract.Authentications;
using Authentications.Write.Facades.Facade.Contract.Services;
using Dramankadeh.Core.Application;
using Dramankadeh.Core.DataModel;
using Dramankadeh.Core.EventBus;
using Dramankadeh.Core.Facade;
using AuthenticationCreatedEvent = DomainRefrence::Authentications.Write.Domains.Domain.Authentications.Events.AuthenticationCreatedEvent;

namespace Authentications.Write.Facades.Facade.Services;

public class AuthenticationFacadeService:FacadeService,IAuthenticationFacadeService
{
    private readonly IEventBus _eventBus;

    public AuthenticationFacadeService(ICommandBus commandBus,IEventBus eventBus) : base(commandBus)
    {
        _eventBus = eventBus;
    }

    public async Task<CommonResultBase> CreateAuthentication(string email, string mobile)
    {
        var id = Guid.Empty;
        _eventBus.Subscribe<AuthenticationCreatedEvent>(@event =>
        {
            id = @event.AuthenticationId;
        } );
       var result= await CommandBus.DispatchAsync(new CreateAuthenticationCommand(mobile, email));
       result.Id = id;
       return result;
    }

    public Task<CommonResultBase> RemoveAuthentication(Guid id)
    {
        return CommandBus.DispatchAsync(new RemoveAuthenticationCommand(id));
    }
}