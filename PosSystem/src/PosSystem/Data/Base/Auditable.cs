using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosSystem.Data
{
    public class Auditable: IAuditable
    {
      public int CreatorId { get; set; }
      public DateTime DateCreated { get; set; }
      public int LastModifierId { get; set; }
      public DateTime DateModified { get; set; }
    }
}
