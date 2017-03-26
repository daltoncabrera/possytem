using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PosSystem.Core;

namespace PosSystem.Data.Repos
{
  public class TenantRepository : Repository<Tenant>
  {
    private TenantApplicationUserRepository _tenantApplicationUserRepository;
    public TenantRepository(IUnitOfWork uow) : base(uow)
    {
      _tenantApplicationUserRepository = new TenantApplicationUserRepository(uow);
    }

    public void AddUserToTenant(ApplicationUser user, Tenant tenant)
    {
      if(!_tenantApplicationUserRepository.All.Any(s => s.ApplicationUserId == user.Id && s.TenantId == tenant.Id))
      {
        _tenantApplicationUserRepository.Insert(new TenantApplicationUser() { ApplicationUserId = user.Id, TenantId =  tenant.Id}); 
      }
    }
  }
}
