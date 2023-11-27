using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class AppContext : IdentityDbContext<ApplicationUser>
    {
        public AppContext (DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<Bedrijf> Bedrijf { get; set; } = default!;
        // public DbSet<PanelMember> PanelMembers { get; set; }
        // public DbSet<BusinessUser> BusinessUsers { get; set; }
        // public DbSet<Administrator> Administrators { get; set; }
    }
