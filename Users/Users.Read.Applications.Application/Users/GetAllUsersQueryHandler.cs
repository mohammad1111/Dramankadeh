using Dramankadeh.Core.ApplicationRead;
using Microsoft.EntityFrameworkCore;
using Users.Read.Applications.Application.Contract.Queries;
using Users.Read.Applications.Application.Contract.ViewModels;
using Users.Read.ReadModel;

namespace Users.Read.Applications.Application.Users;

public class GetAllUsersQueryHandler:IQueryHandler<GetAllUsersQuery,IList<UsersViewModel>>
{
    private readonly UsersReadDbContext _usersReadDbContext;

    public GetAllUsersQueryHandler(UsersReadDbContext usersReadDbContext)
    {
        _usersReadDbContext = usersReadDbContext;
    }
    
    public async Task<IList<UsersViewModel>> Handler(GetAllUsersQuery query)
    {
        return await _usersReadDbContext.Users.Select(x=> new UsersViewModel
        {
            Id =x.Id,
            AuthenticationId =x.AuthenticationId,
            Address =x.Address,
            Lastname =x.Lastname,
            Firstname =x.Firstname
        }).ToListAsync();
    }
}