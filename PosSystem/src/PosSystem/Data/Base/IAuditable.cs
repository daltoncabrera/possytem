using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosSystem.Data
{
    public interface IAuditable
    {
      int CreatorId { get; set; }
      DateTime DateCreated { get; set; }
      int LastModifierId { get; set; }
      DateTime DateModified { get; set; }
    }
}
