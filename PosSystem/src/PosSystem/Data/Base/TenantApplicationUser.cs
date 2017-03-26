using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosSystem.Data
{
  public class TenantApplicationUser
  {
    public TenantApplicationUser()
    {
    
    }

    public int TenantId { get; set; }

    public int ApplicationUserId { get; set; }

    [ForeignKey("TenantId")]
    public Tenant Tenant { get; set; }

    [ForeignKey("ApplicationUserId")]
    public ApplicationUser ApplicationUser { get; set; }
  }
}
