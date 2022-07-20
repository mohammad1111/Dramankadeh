using Dramankadeh.Core.Application;

namespace Authentications.Write.Applications.Application.Contract.Authentications;

public class CreateAuthenticationCommand:ICommand
{
    public string MobileNumber { get; }
    public string EmailAddress { get; }

    public CreateAuthenticationCommand(string mobileNumber,string emailAddress)
    {
        MobileNumber = mobileNumber;
        EmailAddress = emailAddress;
    }
}