using Darmankadeh.Core.Domain;

namespace Authentications.Write.Domains.Domain.Authentications.Exceptions;

public class EmailIsNotValidException : DomainException
{
    public EmailIsNotValidException(string email) : base($"email '{email}' is not valid")
    {
    }
}