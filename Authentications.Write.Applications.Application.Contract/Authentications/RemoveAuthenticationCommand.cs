using Dramankadeh.Core.Application;

namespace Authentications.Write.Applications.Application.Contract.Authentications;

public class RemoveAuthenticationCommand : ICommand
{
    public Guid AuthenticationId { get; }

    public RemoveAuthenticationCommand(Guid authenticationId)
    {
        AuthenticationId = authenticationId;
    }
}