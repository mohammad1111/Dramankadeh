using Dramankadeh.Core.Application;
using Dramankadeh.Core.EventBus;

namespace Dramankadeh.Core.Facade;

public abstract class FacadeService
{
    private readonly ICommandBus _commandBus;

    protected FacadeService(ICommandBus commandBus)
    {
        _commandBus = commandBus;
    }
}