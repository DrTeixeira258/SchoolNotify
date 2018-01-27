using SchoolNotify.Domain.Interfaces.Repository.Base;
using SchoolNotify.Infrastructure.Data.Context;
using SchoolNotify.Infrastructure.Data.Interfaces.Management;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolNotify.Infrastructure.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ContextManager _contextManager = ServiceLocator.Current.GetInstance<IContextManager>() as ContextManager;
        protected DbSet<TEntity> DbSet;
        protected readonly DbContext Context;

        public BaseRepository()
        {
            Context = _contextManager.GetContext();
            DbSet = Context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public TEntity AddReturn(TEntity obj)
        {
            return DbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
        }
        public virtual void Delete(int id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }

        public virtual void Delete(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Deleted;
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GetByIdReadOnly(int id)
        {
            SetContextAsReadOnly();
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllReadOnly()
        {
            SetContextAsReadOnly();
            return await DbSet.ToListAsync<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllReadOnly(string[] includes = null)
        {
            SetContextAsReadOnly();
            IQueryable<TEntity> qr = GetEntitiesWithIncudes(includes);
            return await qr.AsNoTracking().ToListAsync<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, string[] includes = null)
        {
            IQueryable<TEntity> qr = GetEntitiesWithIncudes(includes);
            return await qr.Where(predicate).AsNoTracking().ToListAsync<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetWithTracking(Expression<Func<TEntity, bool>> predicate, string[] includes = null)
        {
            IQueryable<TEntity> qr = GetEntitiesWithIncudes(includes);
            return await qr.Where(predicate).ToListAsync<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetReadOnly(Expression<Func<TEntity, bool>> predicate, string[] includes = null)
        {
            SetContextAsReadOnly();
            IQueryable<TEntity> qr = GetEntitiesWithIncudes(includes);
            return await qr.Where(predicate).AsNoTracking().ToListAsync<TEntity>();
        }

        private IQueryable<TEntity> GetEntitiesWithIncudes(string[] includes)
        {
            IQueryable<TEntity> qr = DbSet;
            if (includes != null)
            {
                for (int i = 0; i < includes.Count(); i++)
                {
                    qr = qr.Include(includes[i]);
                }
            }

            return qr;
        }

        private void SetContextAsReadOnly()
        {
            Context.Configuration.ProxyCreationEnabled = false;
            Context.Configuration.LazyLoadingEnabled = false;
            Context.Configuration.AutoDetectChangesEnabled = false;
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
