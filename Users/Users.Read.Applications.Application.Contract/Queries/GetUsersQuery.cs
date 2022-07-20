using Dramankadeh.Core.ApplicationRead;

namespace Users.Read.Applications.Application.Contract.Queries;

public class GetUsersQuery : IQuery
{
    public Guid Id { get; }

    public GetUsersQuery(Guid id)
    {
        Id = id;
    }
}