namespace Darmankadeh.Core.Domain;

public interface IRepository<TEntity> : IRepository where TEntity : Entity
{
    Task<TEntity> GetByIdAsync(Guid id);
}

public interface IRepository
{
}