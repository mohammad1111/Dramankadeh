using System.ComponentModel.DataAnnotations;

namespace Authentications.Read.ReadModel;

public class Authentication
{
    [Key]
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Mobile { get; set; }
    
}