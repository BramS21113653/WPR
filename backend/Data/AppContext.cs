using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

public class AppContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
    }

    public DbSet<Research> Researches { get; set; }
    public DbSet<Participation> Participations { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<ParentGuardian> ParentGuardians { get; set; }
    public DbSet<PanelMember> PanelMembers { get; set; }
    public DbSet<BusinessUser> BusinessUsers { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<ResearchInterest> ResearchInterests { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure discriminator for TPH (if using TPH)
        modelBuilder.Entity<ApplicationUser>()
            .HasDiscriminator<string>("UserType")
            .HasValue<PanelMember>("PanelMember")
            .HasValue<BusinessUser>("BusinessUser")
            .HasValue<Administrator>("Administrator");
            // Add other derived types as needed

        modelBuilder.Entity<Chat>()
            .HasOne(c => c.PanelMember)
            .WithMany() // Afhankelijk van je relatie
            .HasForeignKey(c => c.PanelMemberId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Chat>()
            .HasOne(c => c.BusinessUser)
            .WithMany() // Afhankelijk van je relatie
            .HasForeignKey(c => c.BusinessUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ChatMessage>()
            .HasOne(cm => cm.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(cm => cm.ChatId);

        modelBuilder.Entity<Chat>()
            .HasOne(c => c.Research)
            .WithMany()
            .HasForeignKey(c => c.ResearchId)
            .OnDelete(DeleteBehavior.Restrict); 

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
        modelBuilder.Entity<PanelMember>()
            .HasOne(pm => pm.ParentGuardian)
            .WithMany(pg => pg.PanelMembers)
            .HasForeignKey(pm => pm.ParentGuardianId)
            .OnDelete(DeleteBehavior.Restrict);

        // Research Relationships
        modelBuilder.Entity<Research>()
            .HasOne(r => r.Conductor)
            .WithMany(bu => bu.Researches)
            .HasForeignKey(r => r.ConductorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Participation Relationships
        modelBuilder.Entity<Participation>()
            .HasOne(p => p.PanelMember)
            .WithMany(pm => pm.Participations)
            .HasForeignKey(p => p.PanelMemberId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Participation>()
            .HasOne(p => p.Research)
            .WithMany(r => r.Participations)
            .HasForeignKey(p => p.ResearchId)
            .OnDelete(DeleteBehavior.Restrict);

        // Administrator Relationships
        modelBuilder.Entity<Administrator>()
            .HasMany(a => a.SupervisedPanelMembers)
            .WithOne(pm => pm.Administrator)
            .HasForeignKey(pm => pm.AdministratorId)
            .OnDelete(DeleteBehavior.Restrict);

        // BusinessUser Relationships
        modelBuilder.Entity<BusinessUser>()
            .HasMany(bu => bu.CreatedMessages)
            .WithOne(m => m.BusinessUser)
            .HasForeignKey(m => m.BusinessUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // ParentGuardian Relationships
        modelBuilder.Entity<ParentGuardian>()
            .HasMany(pg => pg.PanelMembers)
            .WithOne(pm => pm.ParentGuardian)
            .HasForeignKey(pm => pm.ParentGuardianId)
            .OnDelete(DeleteBehavior.Restrict);

        // ResearchInterest relaties tussen research en panelmember (tussentabel)
        modelBuilder.Entity<ResearchInterest>()
            .HasKey(ri => new { ri.PanelMemberId, ri.ResearchId });

        modelBuilder.Entity<ResearchInterest>()
            .HasOne(ri => ri.PanelMember)
            .WithMany(pm => pm.ResearchInterests)
            .HasForeignKey(ri => ri.PanelMemberId);

        modelBuilder.Entity<ResearchInterest>()
            .HasOne(ri => ri.Research)
            .WithMany(r => r.ResearchInterests)
            .HasForeignKey(ri => ri.ResearchId);
    }
}
