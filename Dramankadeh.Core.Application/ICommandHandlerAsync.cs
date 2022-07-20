using Dramankadeh.Core.DataProvider;

namespace Dramankadeh.Core.Application;

public interface ICommandHandlerAsync<in TCommand> 
{
    IUnitOfWork UnitOfWork { get; }
    Task HandleAsync(TCommand command);
}