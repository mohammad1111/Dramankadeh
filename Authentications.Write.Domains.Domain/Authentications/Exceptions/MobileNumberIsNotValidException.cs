using Darmankadeh.Core.Domain;

namespace Authentications.Write.Domains.Domain.Authentications.Exceptions;

public class MobileNumberIsNotValidException : DomainException
{
    public MobileNumberIsNotValidException(string mobile) : base($"mobile number '{mobile}' is not valid")
    {
    }
}