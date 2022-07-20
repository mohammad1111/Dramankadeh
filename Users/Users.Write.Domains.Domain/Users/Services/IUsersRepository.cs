using Darmankadeh.Core.Domain;

namespace Users.Write.Domains.Domain.Users.Services;

public interface IUsersRepository:IRepository<User>
{
    Task RemoveAsync(User user);

    Task AddAsync(User user);
}