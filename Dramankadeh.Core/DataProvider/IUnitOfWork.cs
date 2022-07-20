using Dramankadeh.Core.EventBus;

namespace Dramankadeh.Core.DataProvider;

public interface IUnitOfWork
{
    Task<IList<IEvent>> Commit();
}