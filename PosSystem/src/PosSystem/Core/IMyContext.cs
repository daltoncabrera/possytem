using System;
using System.Collections.Generic;
using System.Linq;

namespace PosSystem.Core
{
  public interface IMyContext : IDisposable
  {
    int SaveChanges();
  }
}