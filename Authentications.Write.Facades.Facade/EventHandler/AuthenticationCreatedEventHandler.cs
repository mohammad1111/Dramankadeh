using Authentications.Write.Facades.Facade.Contract.Services;
using Dramankadeh.Core.EventBus;
using MassTransit;

namespace Authentications.Write.Facades.Facade.EventHandler;

extern alias ShareRefrence;

public class AuthenticationCreatedEventHandler:IConsumer<ShareRefrence::Dramankadeh.ShareProjects.ShareModel.CreateUserEvents.UserNeedAuthenticationEvent>
{
    private readonly IAuthenticationFacadeService _authenticationFacadeService;
    private readonly IEventBus _eventBus;

    public AuthenticationCreatedEventHandler(IAuthenticationFacadeService authenticationFacadeService,IEventBus eventBus)
    {
        _authenticationFacadeService = authenticationFacadeService;
        _eventBus = eventBus;
    }
    
    public async Task Consume(ConsumeContext<ShareRefrence::Dramankadeh.ShareProjects.ShareModel.CreateUserEvents.UserNeedAuthenticationEvent> context)
    {
        var result =await 
            _authenticationFacadeService.CreateAuthentication(context.Message.Email,
                context.Message.Mobile);
        if (result.HasError)
        {
            await _eventBus.PublishAsync(new ShareRefrence::Dramankadeh.ShareProjects.ShareModel.CreateUserEvents.CreateAuthenticationHasExceptionEvent
            {
                Email = context.Message.Email,
                CorrelationEventId = NewId.NextGuid()
            });
        }
    }
}