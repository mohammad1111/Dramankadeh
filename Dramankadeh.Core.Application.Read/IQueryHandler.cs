namespace Dramankadeh.Core.ApplicationRead;

public interface IQueryHandler<TQuery,TResult> 
where TQuery : IQuery
{

    Task<TResult> Handler(TQuery query);
}