using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PosSystem.Models;
using PosSystem.Core;

namespace PosSystem.Data
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>, IMyContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      // Customize the ASP.NET Identity model and override the defaults if needed.
      // For example, you can rename the ASP.NET Identity table names and more.
      // Add your customizations after calling base.OnModelCreating(builder);

      builder.Entity<TenantApplicationUser>()
        .HasKey(s => new { s.ApplicationUserId, s.TenantId });

      builder.Entity<TenantApplicationUser>()
       .HasOne(pc => pc.ApplicationUser)
       .WithMany(p => p.TenantApplicationUsers)
       .HasForeignKey(pc => pc.ApplicationUserId);



      builder.Entity<TenantApplicationUser>()
          .HasOne(pc => pc.Tenant)
          .WithMany(c => c.TenantApplicationUsers)
          .HasForeignKey(pc => pc.TenantId);
    }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantApplicationUser> TenantApplicationUsers { get; set; }

  }
}
