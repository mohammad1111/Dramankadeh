using Dramankadeh.Core.Application;
using Dramankadeh.Core.DataProvider;
using Users.Write.Applications.Application.Contract.Users;
using Users.Write.Domains.Domain.Users.Services;

namespace Users.Write.Applications.Application.Authentications;

public class RemoveUsersCommandHandler:CommandHandlerBase,ICommandHandlerAsync<RemoveUsersCommand>
{
    private readonly IUsersRepository _repository;

    public RemoveUsersCommandHandler(IUnitOfWork unitOfWork,IUsersRepository repository) : base(unitOfWork)
    {
        _repository = repository;
    }

    public async Task HandleAsync(RemoveUsersCommand command)
    {
        var Users=await _repository.GetByIdAsync(command.UsersId);
        Users.Remove();
        await _repository.RemoveAsync(Users);
    }
}