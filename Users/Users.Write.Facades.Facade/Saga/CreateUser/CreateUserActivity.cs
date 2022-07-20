using Authentications.Write.Domains.Domain.Authentications.Events;
using Dramankadeh.Core.EventBus;
using Dramankadeh.ShareProjects.ShareModel.CreateUserEvents;
using MassTransit;
using Users.Write.Facades.Facade.Contract.Models;
using Users.Write.Facades.Facade.Contract.Services;

namespace Users.Write.Facades.Facade.Saga.CreateUser;

public class CreateUserActivity : IStateMachineActivity<CreateUserState,AuthenticationCreatedEvent>
{
    private readonly IUserFacadeService _userFacadeService;
    private readonly IEventBus _eventBus;

    public CreateUserActivity(IUserFacadeService userFacadeService,IEventBus eventBus)
    {
        _userFacadeService = userFacadeService;
        _eventBus = eventBus;
    }


    public async Task CreatUser(CreateUserState state)
    {
        var result=await  _userFacadeService.CreateUsers(state.Firstname, state.Lastname, state.Address, state.AuthenticationId);
        if (result.HasError)
        {
            await _eventBus.PublishAsync(new CreateUserHasExceptionEvent
            {
                Email = state.Email,
                CorrelationEventId = state.CorrelationId
            });
        }
    }


    public void Probe(ProbeContext context)
    {
        context.CreateScope(nameof(AuthenticationCreatedEvent));
    }

    public void Accept(StateMachineVisitor visitor)
    {
        visitor.Visit(this);
    }


    public async Task Execute(BehaviorContext<CreateUserState, AuthenticationCreatedEvent> context, IBehavior<CreateUserState, AuthenticationCreatedEvent> next)
    {
        await CreatUser(context.Saga);
        await next.Execute(context).ConfigureAwait(false);
    }

    public async Task Faulted<TException>(BehaviorExceptionContext<CreateUserState, AuthenticationCreatedEvent, TException> context, IBehavior<CreateUserState, AuthenticationCreatedEvent> next) where TException : Exception
    {
       await next.Faulted(context).ConfigureAwait(false);
    }
}