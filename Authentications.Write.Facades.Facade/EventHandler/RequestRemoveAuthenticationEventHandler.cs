using Authentications.Write.Facades.Facade.Contract.Services;
using MassTransit;

namespace Authentications.Write.Facades.Facade.EventHandler;

extern alias ShareRefrence;

public class RequestRemoveAuthenticationEventHandler : IConsumer<ShareRefrence::Dramankadeh.ShareProjects.ShareModel.CreateUserEvents.RequestRemoveAuthenticationEvent>
{
    private readonly IAuthenticationFacadeService _facadeService;

    public RequestRemoveAuthenticationEventHandler(IAuthenticationFacadeService facadeService)
    {
        _facadeService = facadeService;
    }
    public async Task Consume(ConsumeContext<ShareRefrence::Dramankadeh.ShareProjects.ShareModel.CreateUserEvents.RequestRemoveAuthenticationEvent> context)
    {
        await   _facadeService.RemoveAuthentication(context.Message.AuthenticationId);
    }
}