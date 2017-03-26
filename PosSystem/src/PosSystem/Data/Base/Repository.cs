using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosSystem.Core;

namespace PosSystem.Data
{
  public class Repository<T> : IRepository<T> where T : class
  {
    private readonly ApplicationDbContext context;
    public IUnitOfWork UOW { get; private set; }
    public IQueryable<T> All
    {
      get { return context.Set<T>(); }
    }

    public Repository(IUnitOfWork uow)
    {
      context = uow.MyContext as ApplicationDbContext;
      UOW = uow;
    }

    public IQueryable<T> AllEager(params Expression<Func<T, object>>[] includes)
    {
      var query = context.Set<T>();
      foreach (var incl in includes)
      {
        query.Include(incl);
      }

      return query;
    }


    public void Insert(T entity)
    {
      context.Entry(entity).State = EntityState.Added;
    }

    public void Update(T entity)
    {
      context.Set<T>().Attach(entity);
      context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
      context.Set<T>().Remove(entity);
    }

    public void Dispose()
    {
      if (context != null)
      {
        context.Dispose();
      }
    }
  }
}
