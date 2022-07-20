using Darmankadeh.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dramankadeh.Core.Persistence.Ef;

public abstract class EntityMapperBase<TEntity> : IEntityMapper
    where TEntity : Entity
{
    public Type MapperType => typeof(TEntity);

    public virtual void Map(ModelBuilder modelBuilder)
    {
    }
}