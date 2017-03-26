using System;
using System.Collections.Generic;
using System.Linq;
using RepoScraper.Core;

namespace Reposystem.IRepoDataScraper.Data
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