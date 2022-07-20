namespace Dramankadeh.Core.Application;

public interface ICommandHandlerFactory
{
    ICommandHandlerAsync<T> CreateHandler<T>()
        where T : ICommand;
}