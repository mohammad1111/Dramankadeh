using Dramankadeh.Core.DataProvider;
using Dramankadeh.Core.EventBus;
using Microsoft.EntityFrameworkCore;

namespace Dramankadeh.Core.Persistence.Ef;

public class DramankadehDbContext : DbContext, IUnitOfWork
{
    public DramankadehDbContext(DbContextOptions<EfUnitOfWork> options) : base(options)
    {
    }


    public virtual Task<IList<IEvent>> Commit()
    {
        throw new NotImplementedException();
    }
}