using Dramankadeh.Core.EventBus;
using Dramankadeh.ShareProjects.ShareModel.CreateUserEvents;
using MassTransit;

namespace Users.Write.Facades.Facade.Saga.CreateUser;

public class CreateUserService : ICreateUserService
{
    private readonly IEventBus _eventBus;

    public CreateUserService(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }
    public async Task CreateUser(string email,string mobile,string firstname,string lastname,string address)
    {
        await  _eventBus.PublishAsync(new UserNeedAuthenticationEvent
        {
            Email = email,
            Mobile = mobile,
            CorrelationEventId = NewId.NextGuid(),
            Address = address,
            Firstname = firstname,
            Lastname = lastname
        });
    }
}