using System.Linq.Expressions;
using Darmankadeh.Core.Domain;
using Dramankadeh.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Dramankadeh.Core.Persistence.Ef;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly DramankadehDbContext _dramankadehDbContext;

    protected RepositoryBase(DramankadehDbContext dramankadehDbContext)
    {
        _dramankadehDbContext = dramankadehDbContext;
    }

    public virtual async Task<TEntity> GetByIdAsync(Guid id)
    {
        var aggregateQuery = ConvertToAggregate(_dramankadehDbContext.Set<TEntity>().AsQueryable());

        var result = await aggregateQuery.FirstOrDefaultAsync(x => x.Id == id);

        if (result == null) throw new FrameworkException($"داده ای با شناسه {id} و سطح دسترسی شما پیدا نشد ");

        return result;
    }

    public async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        var aggregateQuery = ConvertToAggregate(_dramankadehDbContext.Set<TEntity>().AsQueryable());
        var result = await aggregateQuery.Where(x => ids.Contains(x.Id)).ToListAsync();
        if (result.Any()) throw new Exception("اطلاعات پیدا نشد");

        return result;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dramankadehDbContext.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<TEntity> entities)
    {
        await _dramankadehDbContext.AddRangeAsync(entities);
    }

    public async Task RemoveAsync(TEntity entity)
    {
        await Task.Factory.StartNew(() =>
        {
            _dramankadehDbContext.Set<TEntity>().Attach(entity);
            _dramankadehDbContext.Set<TEntity>().Remove(entity);
        });
    }

    public IQueryable<TEntity> ConvertToAggregate(IQueryable<TEntity> set)
    {
        var result = set;
        var includeExpressions = GetIncludeExpressions();
        if (includeExpressions != null)
            foreach (var expression in includeExpressions)
                result = result.Include(expression);

        return result;
    }

    protected abstract IEnumerable<Expression<Func<TEntity, object>>> GetIncludeExpressions();
}