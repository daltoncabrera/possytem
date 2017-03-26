using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PosSystem.Core;

namespace PosSystem.Data.Repos
{
    public class TenantApplicationUserRepository : Repository<TenantApplicationUser>
    {
      public TenantApplicationUserRepository(IUnitOfWork uow) : base(uow)
      {
      }
    }
}
