using Dramankadeh.Core;
using Dramankadeh.Core.Persistence.Ef;
using Dramankadeh.Core.Serilizer;
using Dramankadeh.Core.Settings;
using Microsoft.EntityFrameworkCore;

namespace Users.Infrastructure.Persistence;

public class UsersDbContext : EfUnitOfWork
{
    public UsersDbContext(IDataSettings dataSettings, DbContextOptions<EfUnitOfWork> options,
        ISerializer serializer, IServiceLocator serviceLocator) : base(dataSettings.ConnectionString,
        dataSettings.MicroServiceName, options, serializer, serviceLocator)
    {
    }
}