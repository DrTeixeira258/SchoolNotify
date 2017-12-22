using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllReadOnly();
        IEnumerable<T> GetAllReadOnly(string[] includes);
        T GetById(int id);
        T Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindReadOnly(Expression<Func<T, bool>> predicate, string[] includes);
        T Add(T obj);
        void Edit(int id);
        void Remove(int id);
    }
}
