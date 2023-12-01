using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class AppContext : IdentityDbContext<ApplicationUser>
{
    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         optionsBuilder.UseMySql("Your_MariaDB_Connection_String", 
    //             new MariaDbServerVersion(new Version(10, 5))); // Specify your MariaDB version here
    //     }
    // }

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


    // Message Relationships
    modelBuilder.Entity<Message>()
        .HasOne(m => m.Sender)
        .WithMany(u => u.MessagesSent)
        .HasForeignKey(m => m.SenderId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Message>()
        .HasOne(m => m.Receiver)
        .WithMany(u => u.MessagesReceived)
        .HasForeignKey(m => m.ReceiverId)
        .OnDelete(DeleteBehavior.Restrict);

    // PanelMember Relationships
    // Assuming PanelMember has a foreign key for ParentGuardian
    modelBuilder.Entity<PanelMember>()
        .HasOne(pm => pm.ParentGuardian)
        .WithMany(pg => pg.PanelMembers)
        .HasForeignKey(pm => pm.ParentGuardianId)
        .OnDelete(DeleteBehavior.Restrict); // Adjust as per your requirement

    // Research Relationships
    // Assuming Research has a foreign key for BusinessUser (as Conductor)
    modelBuilder.Entity<Research>()
        .HasOne(r => r.Conductor)
        .WithMany(bu => bu.Researches)
        .HasForeignKey(r => r.ConductorId)
        .OnDelete(DeleteBehavior.Restrict); // Adjust as per your requirement

    // Participation Relationships
    modelBuilder.Entity<Participation>()
        .HasOne(p => p.PanelMember)
        .WithMany(pm => pm.Participations)
        .HasForeignKey(p => p.PanelMemberId)
        .OnDelete(DeleteBehavior.Restrict); // Adjust as per your requirement

    modelBuilder.Entity<Participation>()
        .HasOne(p => p.Research)
        .WithMany(r => r.Participations)
        .HasForeignKey(p => p.ResearchId)
        .OnDelete(DeleteBehavior.Restrict); // Adjust as per your requirement

    // Administrator Relationships
    // Assuming Administrator has specific relationships, configure them here.
    // For example, if Administrator oversees PanelMembers:
    modelBuilder.Entity<Administrator>()
        .HasMany(a => a.SupervisedPanelMembers) // Replace with actual collection property
        .WithOne(pm => pm.Administrator) // Replace with the reference property in PanelMember
        .HasForeignKey(pm => pm.AdministratorId) // Replace with the foreign key property in PanelMember
        .OnDelete(DeleteBehavior.Restrict);

    // BusinessUser Relationships
    // Assuming BusinessUser has specific relationships, configure them here.
    // For example, if BusinessUser creates Messages:
    modelBuilder.Entity<BusinessUser>()
        .HasMany(bu => bu.CreatedMessages) // Replace with actual collection property
        .WithOne(m => m.BusinessUser) // Replace with the reference property in Message
        .HasForeignKey(m => m.BusinessUserId) // Replace with the foreign key property in Message
        .OnDelete(DeleteBehavior.Restrict);

    // ParentGuardian Relationships
    // Assuming ParentGuardian has specific relationships, configure them here.
    // For example, if ParentGuardian is associated with PanelMembers:
    modelBuilder.Entity<ParentGuardian>()
        .HasMany(pg => pg.PanelMembers) // Replace with actual collection property
        .WithOne(pm => pm.ParentGuardian) // Replace with the reference property in PanelMember
        .HasForeignKey(pm => pm.ParentGuardianId) // Replace with the foreign key property in PanelMember
        .OnDelete(DeleteBehavior.Restrict);
    }
}
