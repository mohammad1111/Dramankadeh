using Authentications.Write.Applications.Application.Contract.Authentications;
using Authentications.Write.Domains.Domain.Authentications;
using Authentications.Write.Domains.Domain.Authentications.Services;
using Dramankadeh.Core.Application;
using Dramankadeh.Core.DataProvider;

namespace Authentications.Write.Applications.Application.Authentications;

public class CreateAuthenticationCommandHandler:CommandHandlerBase,ICommandHandlerAsync<CreateAuthenticationCommand>
{
    private readonly IAuthenticationRepository _repository;

    public CreateAuthenticationCommandHandler(IUnitOfWork unitOfWork,IAuthenticationRepository repository) : base(unitOfWork)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateAuthenticationCommand command)
    {
        var authentication = new Authentication(command.EmailAddress, command.MobileNumber);
        await _repository.AddAsync(authentication);
    }
}