using Authentications.Write.Domains.Domain.Authentications.Events;
using MassTransit;
using Authentications.Read.ReadModel;

namespace Authentications.Read.Facades.Facade.Services.EventHandler;

public class AuthenticationRemovedEventHandler:IConsumer<AuthenticationRemovedEvent>
{
    private readonly AuthenticationReadDbContext _dbContext;

    public AuthenticationRemovedEventHandler(AuthenticationReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Consume(ConsumeContext<AuthenticationRemovedEvent> context)
    {
        _dbContext.SetWriteMode();
        var authentication = new Authentication
        {
            Id = context.Message.AuthenticationId
        };
        _dbContext.Attach(authentication);
        _dbContext.Remove(authentication);
        await _dbContext.SaveChangesAsync();
    }
}