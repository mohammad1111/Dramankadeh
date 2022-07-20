using Authentications.Read.Applications.Application.Contract.Queries;
using Authentications.Read.Applications.Application.Contract.ViewModels;
using Dramankadeh.Core.Facade.Read;

namespace Authentications.Read.Facades.Facade.Services.Contract.Services;

public interface IAuthenticationFacadeReadService:IFacadeReadService
{
    Task<IList<AuthenticationViewModel>> GetAll();
    Task<AuthenticationViewModel> GetById(Guid id);
}