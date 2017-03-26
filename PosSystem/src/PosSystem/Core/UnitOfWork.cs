using System;
using System.Collections.Generic;
using System.Linq;

namespace PosSystem.Core
{
  public class UnitOfWork:IUnitOfWork
  {
    public IMyContext MyContext { get; }


    public UnitOfWork(IMyContext context)
    {
      MyContext = context;
    }

    public int Save()
    {
      return MyContext.SaveChanges();
    }

    public void Dispose()
    {
      if (MyContext != null)
      {
        MyContext.Dispose();
      }
    }
  }
}