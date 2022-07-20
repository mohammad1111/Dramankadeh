using Dramankadeh.Core.ApplicationRead;

namespace Dramankadeh.Core.Facade.Read;

public abstract class FacadeReadService
{
    public IQueryBus QueryBus { get; }

    protected FacadeReadService(IQueryBus queryBus)
    {
        QueryBus = queryBus;
    }
}