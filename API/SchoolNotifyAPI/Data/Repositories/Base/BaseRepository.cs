using Data.Context;
using Data.Interfaces.Managers;
using Domain.Interfaces.Repositories.Base;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ContextManager _contextManager = ServiceLocator.Current.GetInstance<IContextManager>() as ContextManager;
        protected IDbSet<T> DbSet;
        protected readonly DbContext Context;

        protected SchoolNotifyContext Db;

        public BaseRepository()
        {
            Context = _contextManager.GetContext();
            DbSet = Context.Set<T>();
        }

        public virtual T Add(T obj)
        {
            DbSet.Add(obj);
            return obj;
        }

        public virtual void Edit(int id)
        {
            var objDb = DbSet.Find(id);
            var entry = Context.Entry(objDb);
            entry.State = EntityState.Modified;
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            List<T> list;
            using (Db = new SchoolNotifyContext())
            {
                Db.Database.Log = s => Debug.WriteLine(s);

                list = DbSet.Where(predicate).AsNoTracking().ToList();
            }
            return list.FirstOrDefault();
        }

        public IEnumerable<T> FindReadOnly(Expression<Func<T, bool>> predicate, string[] includes)
        {
            List<T> list;
            using (Db = new SchoolNotifyContext())
            {
                Db.Configuration.ProxyCreationEnabled = false;
                Db.Configuration.LazyLoadingEnabled = false;
                Db.Database.Log = s => Debug.WriteLine(s);
                IQueryable<T> qr = DbSet.Where(predicate).AsNoTracking();
                if (includes != null)
                {
                    for (var i = 0; i < includes.Count(); i++)
                    {
                        qr = qr.Include(includes[i]);
                    }
                }

                list = qr.AsNoTracking().ToList();
            }
            return list;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public IEnumerable<T> GetAllReadOnly()
        {
            Context.Configuration.ProxyCreationEnabled = false;

            return DbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> GetAllReadOnly(string[] includes)
        {

            List<T> list;
            using (Db = new SchoolNotifyContext())
            {
                Db.Configuration.ProxyCreationEnabled = false;
                Db.Configuration.LazyLoadingEnabled = false;
                Db.Database.Log = s => Debug.WriteLine(s);
                IQueryable<T> qr = Db.Set<T>();
                if (includes != null)
                {
                    for (var i = 0; i < includes.Count(); i++)
                    {
                        qr = qr.Include(includes[i]);
                    }
                }

                list = qr.AsNoTracking().ToList();
            }
            return list;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Remove(int id)
        {
            var objDb = DbSet.Find(id);
            DbSet.Remove(objDb);
        }

        public virtual void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
