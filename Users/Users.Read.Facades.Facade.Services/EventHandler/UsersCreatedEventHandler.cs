using Dramankadeh.ShareProjects.ShareModel.Users;
using MassTransit;
using Users.Read.ReadModel;

namespace Users.Read.Facades.Facade.Services.EventHandler;

public class UsersCreatedEventHandler:IConsumer<UsersCreatedEvent>
{
    private readonly UsersReadDbContext _dbContext;

    public UsersCreatedEventHandler(UsersReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Consume(ConsumeContext<UsersCreatedEvent> context)
    {
        _dbContext.SetWriteMode();
      await  _dbContext.AddAsync(new User
        {
            Firstname = context.Message.Firstname,
            Id = context.Message.UsersId,
            Lastname = context.Message.Lastname,
            AuthenticationId = context.Message.AuthenticationId,
            Address = context.Message.Address
        });
        await _dbContext.SaveChangesAsync();
    }
}