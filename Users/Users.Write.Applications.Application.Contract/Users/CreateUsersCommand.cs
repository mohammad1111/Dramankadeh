using Dramankadeh.Core.Application;

namespace Users.Write.Applications.Application.Contract.Users;

public class CreateUsersCommand:ICommand
{
    public string Firstname { get; }
    
    public string Lastname { get; }
    
    public string Address { get; }
    
    public Guid AuthenticationId { get; }

    public CreateUsersCommand(string firstname, string lastname,string address,Guid authenticationId)
    {
        Firstname = firstname;
        Lastname = lastname;
        Address = address;
        AuthenticationId = authenticationId;
    }
}