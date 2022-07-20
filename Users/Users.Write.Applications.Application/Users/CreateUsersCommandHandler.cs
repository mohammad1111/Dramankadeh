using Dramankadeh.Core.Application;
using Dramankadeh.Core.DataProvider;
using Users.Write.Applications.Application.Contract.Users;
using Users.Write.Domains.Domain.Users;
using Users.Write.Domains.Domain.Users.Services;

namespace Users.Write.Applications.Application.Users;

public class CreateUsersCommandHandler:CommandHandlerBase,ICommandHandlerAsync<CreateUsersCommand>
{
    private readonly IUsersRepository _repository;

    public CreateUsersCommandHandler(IUnitOfWork unitOfWork,IUsersRepository repository) : base(unitOfWork)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateUsersCommand command)
    {
        var users = new User(command.Firstname, command.Lastname,command.Address,command.AuthenticationId);
        await _repository.AddAsync(users);
    }
}