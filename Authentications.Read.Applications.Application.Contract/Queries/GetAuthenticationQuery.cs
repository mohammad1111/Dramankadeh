using Dramankadeh.Core.ApplicationRead;

namespace Authentications.Read.Applications.Application.Contract.Queries;

public class GetAuthenticationQuery : IQuery
{
    public Guid Id { get; }

    public GetAuthenticationQuery(Guid id)
    {
        Id = id;
    }
}