using Dramankadeh.Core.DataModel;
using Dramankadeh.Core.Facade;

namespace Authentications.Write.Facades.Facade.Contract.Services;

public interface IAuthenticationFacadeService:IFacadeService
{

    Task<CommonResultBase> CreateAuthentication(string email,string mobile);
    
    Task<CommonResultBase> RemoveAuthentication(Guid id);

}