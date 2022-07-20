using Authentications.Write.Domains.Domain.Authentications.Events;
using MassTransit;
using Authentications.Read.ReadModel;

namespace Authentications.Read.Facades.Facade.Services.EventHandler;

public class AuthenticationCreatedEventHandler:IConsumer<AuthenticationCreatedEvent>
{
    private readonly AuthenticationReadDbContext _dbContext;

    public AuthenticationCreatedEventHandler(AuthenticationReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Consume(ConsumeContext<AuthenticationCreatedEvent> context)
    {
        _dbContext.SetWriteMode();
      await  _dbContext.AddAsync(new Authentication
        {
            Email = context.Message.EmailAddress,
            Id = context.Message.AuthenticationId,
            Mobile = context.Message.MobileNumber
        });
        await _dbContext.SaveChangesAsync();
    }
}