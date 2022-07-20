using Microsoft.EntityFrameworkCore;

namespace Users.Read.ReadModel;

public class UsersReadDbContext:DbContext
{
    public void SetWriteMode()
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;

    }
    
    public UsersReadDbContext(DbContextOptions<UsersReadDbContext> options):base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    
    public DbSet<User> Users { get;  }
}