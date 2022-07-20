using Users.Write.Applications.Application.Contract.Users;
using Users.Write.Domains.Domain.Users.Events;
using Users.Write.Facades.Facade.Contract.Services;
using Dramankadeh.Core.Application;
using Dramankadeh.Core.DataModel;
using Dramankadeh.Core.EventBus;
using Dramankadeh.Core.Facade;

namespace Users.Write.Facades.Facade.Services;

public class UserFacadeService:FacadeService,IUserFacadeService
{
    private readonly IEventBus _eventBus;

    public UserFacadeService(ICommandBus commandBus,IEventBus eventBus) : base(commandBus)
    {
        _eventBus = eventBus;
    }

    public async Task<CommonResultBase> CreateUsers(string firstname, string lastname,string address,Guid authenticationId)
    {
        var id = Guid.Empty;
        _eventBus.Subscribe<UsersCreatedEvent>(@event =>
        {
            id = @event.UsersId;
        } );
       var result= await CommandBus.DispatchAsync(new CreateUsersCommand(firstname, lastname,address,authenticationId));
       result.Id = id;
       return result;
    }

    public Task<CommonResultBase> RemoveUsers(Guid id)
    {
        return CommandBus.DispatchAsync(new RemoveUsersCommand(id));
    }
}