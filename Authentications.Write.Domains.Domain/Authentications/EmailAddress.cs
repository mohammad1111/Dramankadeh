using System.Text.RegularExpressions;
using Authentications.Write.Domains.Domain.Authentications.Exceptions;
using Darmankadeh.Core.Domain;

namespace Authentications.Write.Domains.Domain.Authentications;

public class EmailAddress : ValueObject
{
    public EmailAddress(string email)
    {
        IsValid(email);
        Email = email;
    }

    public string Email { get; }

    private void IsValid(string email)
    {
        var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        var match = regex.Match(email);
        if (!match.Success) throw new EmailIsNotValidException(email);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Email;
    }
}