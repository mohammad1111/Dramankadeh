using Dramankadeh.Core.DataProvider;

namespace Dramankadeh.Core.Application;

public abstract class CommandHandlerBase
{
    protected CommandHandlerBase(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; }
}