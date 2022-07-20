using Dramankadeh.Core.DataModel;

namespace Dramankadeh.Core.Application;

public interface ICommandBus
{
    Task<GigCommonResultBase> DispatchAsync<T>(T command) where T : ICommand;
}