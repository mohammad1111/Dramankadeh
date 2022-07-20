using Authentications.Read.Applications.Application.Contract.Queries;
using Authentications.Read.Applications.Application.Contract.ViewModels;
using Authentications.Read.Facades.Facade.Services.Contract.Services;
using Dramankadeh.Core.ApplicationRead;
using Dramankadeh.Core.Facade.Read;

namespace Authentications.Read.Facades.Facade.Services.Services;

public class AuthenticationFacadeReadService:FacadeReadService,IAuthenticationFacadeReadService
{
    public AuthenticationFacadeReadService(IQueryBus queryBus) : base(queryBus)
    {
    }

    public async Task<IList<AuthenticationViewModel>> GetAll()
    {
        return await QueryBus.DispatchAsync<GetAllAuthenticationsQuery, IList<AuthenticationViewModel>>(
            new GetAllAuthenticationsQuery());
    }

    public async Task<AuthenticationViewModel> GetById(Guid id)
    {
        return await QueryBus.DispatchAsync<GetAuthenticationQuery, AuthenticationViewModel>(
            new GetAuthenticationQuery(id));
    }
    
}