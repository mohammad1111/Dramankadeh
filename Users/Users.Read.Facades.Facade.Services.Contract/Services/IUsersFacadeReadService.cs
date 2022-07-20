using Users.Read.Applications.Application.Contract.Queries;
using Users.Read.Applications.Application.Contract.ViewModels;
using Dramankadeh.Core.Facade.Read;

namespace Users.Read.Facades.Facade.Services.Contract.Services;

public interface IUsersFacadeReadService:IFacadeReadService
{
    Task<IList<UsersViewModel>> GetAll();
    Task<UsersViewModel> GetById(Guid id);
}