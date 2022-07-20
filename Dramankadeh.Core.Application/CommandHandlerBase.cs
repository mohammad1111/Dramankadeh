using Dramankadeh.Core.DataProvider;

namespace Dramankadeh.Core.Application;

public abstract class CommandHandlerBase
{
   public IUnitOfWork UnitOfWork { get; }

    protected CommandHandlerBase(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}