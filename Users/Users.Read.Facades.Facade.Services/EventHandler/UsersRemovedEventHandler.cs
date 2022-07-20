using Users.Write.Domains.Domain.Users.Events;
using MassTransit;
using Users.Read.ReadModel;

namespace Users.Read.Facades.Facade.Services.EventHandler;

public class UsersRemovedEventHandler:IConsumer<UsersRemovedEvent>
{
    private readonly UsersReadDbContext _dbContext;

    public UsersRemovedEventHandler(UsersReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Consume(ConsumeContext<UsersRemovedEvent> context)
    {
        _dbContext.SetWriteMode();
        var user = new User
        {
            Id = context.Message.UsersId
        };
        _dbContext.Attach(user);
        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync();
    }
}