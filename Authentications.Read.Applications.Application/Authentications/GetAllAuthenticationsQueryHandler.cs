using Authentications.Read.Applications.Application.Contract.Queries;
using Authentications.Read.Applications.Application.Contract.ViewModels;
using Dramankadeh.Core.ApplicationRead;
using Microsoft.EntityFrameworkCore;
using Authentications.Read.ReadModel;

namespace Authentications.Read.Applications.Application.Authentications;

public class GetAllAuthenticationsQueryHandler:IQueryHandler<GetAllAuthenticationsQuery,IList<AuthenticationViewModel>>
{
    private readonly AuthenticationReadDbContext _authenticationReadDbContext;

    public GetAllAuthenticationsQueryHandler(AuthenticationReadDbContext authenticationReadDbContext)
    {
        _authenticationReadDbContext = authenticationReadDbContext;
    }
    
    public async Task<IList<AuthenticationViewModel>> Handler(GetAllAuthenticationsQuery query)
    {
        return await _authenticationReadDbContext.Authentications.Select(x=> new AuthenticationViewModel
        {
            Email = x.Email,
            Mobile = x.Mobile
        }).ToListAsync();
    }
}