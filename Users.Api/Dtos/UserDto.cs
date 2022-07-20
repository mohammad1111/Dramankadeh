namespace Users.Api.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }

    public string Address { get; set; }

}