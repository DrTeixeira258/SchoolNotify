using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolNotify.Domain.Interfaces.Repository.Base
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity AddReturn(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);
        void Delete(TEntity obj);
        Task<TEntity> GetById(int id);
        Task<TEntity> GetByIdReadOnly(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAllReadOnly();
        Task<IEnumerable<TEntity>> GetAllReadOnly(string[] includes = null);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, string[] includes = null);
        Task<IEnumerable<TEntity>> GetReadOnly(Expression<Func<TEntity, bool>> predicate, string[] includes = null);
    }
}
