using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PosSystem.Core
{
  public interface IRepository<T> : IDisposable where T : class 
  {
    IQueryable<T> All { get; }
    IQueryable<T> AllEager(params Expression<Func<T, object>>[] includes);

    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);

  }
}