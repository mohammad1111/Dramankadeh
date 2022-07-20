using Authentications.Write.Applications.Application.Contract.Authentications;
using Authentications.Write.Domains.Domain.Authentications.Services;
using Dramankadeh.Core.Application;
using Dramankadeh.Core.DataProvider;

namespace Authentications.Write.Applications.Application.Authentications;

public class RemoveAuthenticationCommandHandler:CommandHandlerBase,ICommandHandlerAsync<RemoveAuthenticationCommand>
{
    private readonly IAuthenticationRepository _repository;

    public RemoveAuthenticationCommandHandler(IUnitOfWork unitOfWork,IAuthenticationRepository repository) : base(unitOfWork)
    {
        _repository = repository;
    }

    public async Task HandleAsync(RemoveAuthenticationCommand command)
    {
        var authentication=await _repository.GetByIdAsync(command.AuthenticationId);
        authentication.Remove();
        await _repository.RemoveAsync(authentication);
    }
}