using Application.Interfaces.Services.Base;
using Data.Interfaces.Managers;
using Microsoft.Practices.ServiceLocation;
using System;

namespace Application.Services.Base
{
    public class BaseAppService : IBaseAppService, IDisposable
    {
        private IUnitOfWork _uow;

        public BaseAppService()
        {

        }

        public virtual void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }

        public void Dispose()
        {
            this._uow = null;
        }
    }
}
