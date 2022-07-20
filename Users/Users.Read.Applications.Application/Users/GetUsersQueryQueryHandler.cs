using Dramankadeh.Core.ApplicationRead;
using Microsoft.EntityFrameworkCore;
using Users.Read.Applications.Application.Contract.Queries;
using Users.Read.Applications.Application.Contract.ViewModels;
using Users.Read.ReadModel;

namespace Users.Read.Applications.Application.Users;

public class GetUsersQueryQueryHandler:IQueryHandler<GetUsersQuery,UsersViewModel>
{
    private readonly UsersReadDbContext _usersReadDbContext;

    public GetUsersQueryQueryHandler(UsersReadDbContext usersReadDbContext)
    {
        _usersReadDbContext = usersReadDbContext;
    }
    
    public async Task<UsersViewModel> Handler(GetUsersQuery query)
    {
        var user = await _usersReadDbContext.Users.FirstAsync(x => x.Id == query.Id);
        return new UsersViewModel
        {
            Id = user.Id,
            AuthenticationId = user.AuthenticationId,
            Address = user.Address,
            Lastname = user.Lastname,
            Firstname = user.Firstname
        };
    }
}