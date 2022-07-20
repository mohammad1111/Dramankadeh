using System.Text.RegularExpressions;
using Authentications.Write.Domains.Domain.Authentications.Exceptions;
using Darmankadeh.Core.Domain;

namespace Authentications.Write.Domains.Domain.Authentications;

public class MobileNumber : ValueObject
{
    public MobileNumber(string mobile)
    {
        IsValid(mobile);
        Mobile = mobile.Replace("(", "").Replace(")", "").Replace(".", "").Replace("-", "");
    }

    public string Mobile { get; }

    private void IsValid(string mobile)
    {
        var regex = new Regex(@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$");

        var match = regex.Match(mobile);
        if (!match.Success) throw new MobileNumberIsNotValidException(mobile);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Mobile;
    }
}