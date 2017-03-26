using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PosSystem.Data.Repos;
using PosSystem.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PosSystem.Data
{
  public static class ApplicationExtensions
  {
    public static async Task SeedData(this IApplicationBuilder app)
    {
      var ctx = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
      ctx.Database.Migrate();
      var uow = new UnitOfWork(ctx);
      var tenantRepo = new TenantRepository(uow);
      var tenantUserRepo = new TenantApplicationUserRepository(uow);
      var userManager = app.ApplicationServices.GetService<UserManager<ApplicationUser>>();
      var roleManager = app.ApplicationServices.GetService<RoleManager<ApplicationRole>>();

      var role = await roleManager.FindByNameAsync("Admin");
      if (role == null)
      {
        role = new ApplicationRole();
        role.Name = "Admin";
        await roleManager.CreateAsync(role);
      }

      var user = await userManager.FindByNameAsync("admin@possystem.com");
      if (user == null || user.Id <= 0)
      {
        user = new ApplicationUser();
        user.Email = "admin@possystem.com";
        user.UserName = "admin@possystem.com";
        user.EmailConfirmed = true;
        user.PhoneNumberConfirmed = true;
        user.SecurityStamp = Guid.NewGuid().ToString("D");
        await userManager.CreateAsync(user, "Aa123!");
      }

      var tenant = tenantRepo.All.FirstOrDefault(s => s.Name == "Demo");

      if (tenant == null)
      {
        tenant = new Tenant();
        tenant.Name = "Demo";
        tenant.Description = "Tenant for demo";
        tenant.CreatorId = user.Id;
        tenant.DateCreated = DateTime.Now;
        tenantRepo.Insert(tenant);
        uow.Save();
      }


      if (!tenantUserRepo.All.Any(s => s.TenantId == tenant.Id && s.ApplicationUserId == user.Id))
      {
        tenantRepo.AddUserToTenant(user, tenant);
        uow.Save();
      }

    }
  }
}
