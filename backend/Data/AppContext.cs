using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class AppContext : IdentityDbContext<ApplicationUser>
{
    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
    }

    // DbSets for your entities
    public DbSet<ApplicationUser> Users { get; set; } 

    // Separate DbSets for other entities
    public DbSet<Research> Researches { get; set; }
    public DbSet<Participation> Participations { get; set; }
    public DbSet<Message> Messages { get; set; }

    // Note: ParentGuardian is also an ApplicationUser, but if you need to query them specifically, you can include this
    public DbSet<ParentGuardian> ParentGuardians { get; set; } 

    // If you need to specifically query other types of users, include them as well
    public DbSet<PanelMember> PanelMembers { get; set; }
    public DbSet<BusinessUser> BusinessUsers { get; set; }
    public DbSet<Administrator> Administrators { get; set; }

    // ... other DbSets as required

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Additional configurations (Fluent API) go here
        // For example, configuring relationships, properties, etc.
    }
}
