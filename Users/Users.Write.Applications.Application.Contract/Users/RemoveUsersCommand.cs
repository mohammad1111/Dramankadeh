using Dramankadeh.Core.Application;

namespace Users.Write.Applications.Application.Contract.Users;

public class RemoveUsersCommand : ICommand
{
    public Guid UsersId { get; }

    public RemoveUsersCommand(Guid usersId)
    {
        UsersId = usersId;
    }
}