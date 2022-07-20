using Darmankadeh.Core.Domain;

namespace Authentications.Write.Domains.Domain.Authentications.Services;

public interface IAuthenticationRepository:IRepository<Authentication>
{
    Task RemoveAsync(Authentication authentication);

    Task AddAsync(Authentication authentication);
}