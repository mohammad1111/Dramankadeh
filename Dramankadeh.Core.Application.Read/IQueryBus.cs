namespace Dramankadeh.Core.ApplicationRead;

public interface IQueryBus
{
    Task<TResult> DispatchAsync<TQueryCommand, TResult>(TQueryCommand command) where TQueryCommand : IQuery;
    
}