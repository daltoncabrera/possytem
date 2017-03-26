using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosSystem.Data
{
  public class Tenant : Auditable
  {
    public Tenant()
    {
      TenantApplicationUsers = new HashSet<TenantApplicationUser>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

  
    public virtual ICollection<TenantApplicationUser> TenantApplicationUsers { get; set; }
  }
}
