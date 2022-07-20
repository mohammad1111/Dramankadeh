using Microsoft.EntityFrameworkCore;

namespace Authentications.Read.ReadModel;

public class AuthenticationReadDbContext:DbContext
{
    public void SetWriteMode()
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;

    }
    
    public AuthenticationReadDbContext(DbContextOptions<AuthenticationReadDbContext> options):base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    
    public DbSet<Authentication> Authentications { get;  }
}