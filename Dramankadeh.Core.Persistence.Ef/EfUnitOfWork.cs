using Darmankadeh.Core.Domain;
using Dramankadeh.Core.EventBus;
using Dramankadeh.Core.Exceptions;
using Dramankadeh.Core.Serilizer;
using Gig.Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore;

namespace Dramankadeh.Core.Persistence.Ef;

public abstract class EfUnitOfWork : DramankadehDbContext
{
    private readonly string _connectionString;
    private readonly string _microServiceName;
    private readonly ISerializer _serializer;
    private readonly IServiceLocator _serviceLocator;


    protected EfUnitOfWork(string connectionString, string microServiceName, DbContextOptions<EfUnitOfWork> options,
        ISerializer serializer, IServiceLocator serviceLocator)
        : base(options)
    {
        _connectionString = connectionString;
        _microServiceName = microServiceName;
        _serializer = serializer;
        _serviceLocator = serviceLocator;
    }

    private List<PublisherEvent> Events { get; set; }


    public override async Task<IList<IEvent>> Commit()
    {
        var currentEventHandler = await GetInboxEventHandlerByCacheKey();
        var aggregateRoots = ChangeTracker.Entries().Select(x => x.Entity).OfType<AggregateRoot>().ToList();
        Events = GetAllPublisherEventInAggregateRoot(aggregateRoots).ToList();
        var allEvents = aggregateRoots.SelectMany(x => x.Changes).OfType<IEvent>().ToList();


        try
        {
            await SaveOutBoxEvent(Events);
            await SaveInBoxEvent(currentEventHandler);
            await SaveChangesAsync();

            Events.Clear();
            ChangeTracker.Clear();
            return allEvents.ToList();
        }
        catch (DbUpdateConcurrencyException exception)
        {
            ChangeTracker.Clear();
            throw new FrameworkException("اطلاعات تغییر کرده است", exception);
        }
        catch (Exception e)
        {
            if (EfExceptionHelper.IsUniqueConstraintViolation(e))
            {
                var exception = new FrameworkException("اطلاعات تکراری است", e);
                ChangeTracker.Clear();
                throw exception;
            }

            ChangeTracker.Clear();
            throw;
        }
    }

    private Task<(Guid domainEventId, string handlerType)?> GetInboxEventHandlerByCacheKey()
    {
        //Get EventHandler by CacheKey,For save in Inbox
        // await Task.Delay(1);
        return null;
    }


    private Task SaveOutBoxEvent(IList<PublisherEvent> events)
    {
        //Add All publisher Message in DbContext 
        //A scheduler publish unpublished events
        return Task.CompletedTask;
    }

    private async Task SaveInBoxEvent((Guid domainEventId, string handlerType)? currentHandler)
    {
        if (currentHandler != null)
        {
            //save event in Inbox 
        }
    }


    private IEnumerable<PublisherEvent> GetAllPublisherEventInAggregateRoot(List<AggregateRoot> aggregateRoots)
    {
        var savingEvents = new List<PublisherEvent>();
        var aggregateRootIds = aggregateRoots.Select(x => x.Id).ToArray();
        aggregateRoots.AddRange(ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged)
            .Select(x => x.Entity).OfType<AggregateRoot>()
            .Where(x => !aggregateRootIds.Contains(x.Id) && x.Changes.Any()).ToList());
        foreach (var root in aggregateRoots)
        foreach (var domainEvent in root.Changes)
            savingEvents.Add(
                new PublisherEvent(domainEvent,
                    domainEvent.GetType().AssemblyQualifiedName,
                    root.GetType().Name,
                    _serializer));

        return savingEvents;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(_connectionString, x =>
            {
                x.MinBatchSize(5);
                x.MaxBatchSize(100);
                x.MigrationsHistoryTable(
                    "__EFMigrationsHistory",
                    _microServiceName
                );
            });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        var mappers = _serviceLocator.ResolveAll<IEntityMapper>();
        foreach (var mapper in mappers) mapper.Map(modelBuilder);

        Console.WriteLine($"Mappers Count : {mappers.Count()}");
        Console.WriteLine($"Entity count : {modelBuilder.Model.GetEntityTypes().Count()}");

        modelBuilder.SetIdAsKeyOnAllEntities();
        modelBuilder.IgnorePropertyOnAllEntities(nameof(AggregateRoot.Changes));
        modelBuilder.ApplyRowVersionSettingOnAllEntities();
        modelBuilder.DisableIdentitySettingOnAllEntities();

        ConfigureHandleInboxEvent(modelBuilder);
        ConfigurePublisherEventEntity(modelBuilder);
    }


    private void ConfigurePublisherEventEntity(ModelBuilder modelBuilder)
    {
        //map PublisherEventEntity
    }


    private void ConfigureHandleInboxEvent(ModelBuilder modelBuilder)
    {
        //map HandleInboxEvent
    }
}