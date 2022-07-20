using Authentications.Write.Domains.Domain.Authentications.Events;
using Dramankadeh.ShareProjects.ShareModel.CreateUserEvents;
using Dramankadeh.ShareProjects.ShareModel.Users;
using MassTransit;
using Users.Write.Facades.Facade.Contract.Models;

namespace Users.Write.Facades.Facade.Saga.CreateUser;

public class CreateUserStateMachine: MassTransitStateMachine<CreateUserState>
{
    public CreateUserStateMachine()
    {
        Event(() => UserNeedAuthenticationEvent, configurator => configurator.CorrelateBy((state, context) => state.Email == context.Message.Email));
        
        Initially(When(UserNeedAuthenticationEvent).TransitionTo(RequestCreateAuthentication));

        During(RequestCreateAuthentication,When(CreateAuthenticationHasExceptionEvent).ThenAsync(context=> SendResponse()).Finalize());
        
        During(RequestCreateAuthentication,
            When(AuthenticationCreatedEvent).Then(x => x.Saga.AuthenticationId = x.Message.AuthenticationId)
                .Activity(x => x.OfType<CreateUserActivity>()).TransitionTo(AuthenticationCreated));

        During(AuthenticationCreated, When(CreateUserHasExceptionEvent).ThenAsync(async x =>
            await x.Publish(new RequestRemoveAuthenticationEvent
            {
                Email = x.Message.Email,
                AuthenticationId = x.Saga.AuthenticationId,
                CorrelationEventId = x.Saga.CorrelationId
            })).TransitionTo(CreateUserHasException));
        
        During(AuthenticationCreated,When(UsersCreatedEvent).ThenAsync(context=> SendResponse()).Finalize());
        
        
        During(CreateUserHasException,When(AuthenticationRemovedEvent).ThenAsync(context=> SendResponse()).Finalize());
        
        
        SetCompletedWhenFinalized();

    }
    
    public Event<UserNeedAuthenticationEvent> UserNeedAuthenticationEvent { get; private set; }
    public Event<AuthenticationCreatedEvent> AuthenticationCreatedEvent { get; private set; }

    public Event<AuthenticationRemovedEvent> AuthenticationRemovedEvent { get; set; }

    public Event<UsersCreatedEvent> UsersCreatedEvent { get; private set; }
    
    public Event<CreateUserHasExceptionEvent> CreateUserHasExceptionEvent { get; private set; }

    public Event<CreateAuthenticationHasExceptionEvent> CreateAuthenticationHasExceptionEvent { get; private set; }
    
    public State RequestCreateAuthentication { get; private set; }
    public State AuthenticationCreated { get; private set; }
    public State CreateUserHasException { get; set; }


    public Task SendResponse()
    {
        //Can send response to client with SignalR
        return Task.CompletedTask;
    }
}