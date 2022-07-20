using Microsoft.EntityFrameworkCore;

namespace Dramankadeh.Core.Persistence.Ef;

public interface IEntityMapper
{
    Type MapperType { get; }


    void Map(ModelBuilder modelBuilder);
}