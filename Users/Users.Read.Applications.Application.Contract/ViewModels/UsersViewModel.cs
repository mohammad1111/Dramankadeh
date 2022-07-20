namespace Users.Read.Applications.Application.Contract.ViewModels;

public class UsersViewModel
{
    public Guid Id { get; set; }

    public Guid AuthenticationId { get; set; }

    public string Address { get; set; }
    
    public string Lastname { get; set; }
    
    public string Firstname { get; set; }

}