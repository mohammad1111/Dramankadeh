using Dramankadeh.Core.DataModel;
using Dramankadeh.Core.Facade;

namespace Users.Write.Facades.Facade.Contract.Services;

public interface IUserFacadeService:IFacadeService
{

    Task<CommonResultBase> CreateUsers(string firstname, string lastname,string address,Guid authenticationId);
    
    Task<CommonResultBase> RemoveUsers(Guid id);

}