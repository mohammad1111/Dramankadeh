using Users.Read.Applications.Application.Contract.Queries;
using Users.Read.Applications.Application.Contract.ViewModels;
using Users.Read.Facades.Facade.Services.Contract.Services;
using Dramankadeh.Core.ApplicationRead;
using Dramankadeh.Core.Facade.Read;

namespace Users.Read.Facades.Facade.Services.Services;

public class UsersFacadeReadService:FacadeReadService,IUsersFacadeReadService
{
    public UsersFacadeReadService(IQueryBus queryBus) : base(queryBus)
    {
    }

    public async Task<IList<UsersViewModel>> GetAll()
    {
        return await QueryBus.DispatchAsync<GetAllUsersQuery, IList<UsersViewModel>>(
            new GetAllUsersQuery());
    }

    public async Task<UsersViewModel> GetById(Guid id)
    {
        return await QueryBus.DispatchAsync<GetUsersQuery, UsersViewModel>(
            new GetUsersQuery(id));
    }
    
}