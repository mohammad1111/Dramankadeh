using Dramankadeh.Core.Application;

namespace Dramankadeh.Core.Facade;

public abstract class FacadeService
{
    public ICommandBus CommandBus;

    protected FacadeService(ICommandBus commandBus)
    {
        CommandBus = commandBus;
    }
}