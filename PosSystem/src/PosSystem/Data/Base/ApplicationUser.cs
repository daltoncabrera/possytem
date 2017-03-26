using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PosSystem.Data
{
  // Add profile data for application users by adding properties to the ApplicationUser class
  public class ApplicationUser : IdentityUser<int>
  {
    public ApplicationUser()
    {
      TenantApplicationUsers = new HashSet<TenantApplicationUser>();
    }
    public virtual ICollection<TenantApplicationUser> TenantApplicationUsers { get; set; }
  }
}
