using Authentications.Read.Applications.Application.Contract.Queries;
using Authentications.Read.Applications.Application.Contract.ViewModels;
using Dramankadeh.Core.ApplicationRead;
using Microsoft.EntityFrameworkCore;
using Authentications.Read.ReadModel;

namespace Authentications.Read.Applications.Application.Authentications;

public class GetAuthenticationQueryQueryHandler:IQueryHandler<GetAuthenticationQuery,AuthenticationViewModel>
{
    private readonly AuthenticationReadDbContext _authenticationReadDbContext;

    public GetAuthenticationQueryQueryHandler(AuthenticationReadDbContext authenticationReadDbContext)
    {
        _authenticationReadDbContext = authenticationReadDbContext;
    }
    
    public async Task<AuthenticationViewModel> Handler(GetAuthenticationQuery query)
    {
        var authentication = await _authenticationReadDbContext.Authentications.FirstAsync(x => x.Id == query.Id);
        return new AuthenticationViewModel
        {
            Email = authentication.Email,
            Mobile = authentication.Mobile
        };
    }
}