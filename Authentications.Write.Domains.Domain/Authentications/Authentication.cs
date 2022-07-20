using Darmankadeh.Core.Domain;

namespace Authentications.Write.Domains.Domain.Authentications;

public class Authentication:AggregateRoot
{
    private Authentication()
    {
        
    }
    
    public Authentication(string mobile):base(Guid.NewGuid())
    {
        
    }
}