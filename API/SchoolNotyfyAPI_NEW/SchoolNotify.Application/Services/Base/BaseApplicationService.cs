using AutoMapper;
using SchoolNotify.Application.Interfaces.Base;
using SchoolNotify.Domain.Interfaces.Repository.Base;
using SchoolNotify.Infrastructure.Data.Interfaces.Management;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Services.Base
{
    public class BaseApplicationService : IBaseApplicationService
    {
        private IUnitOfWork _uow;

        public virtual async Task BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            await Task.Run(() => _uow.BeginTransaction());
        }

        public virtual async Task Commit()
        {
            await Task.Run(() => _uow.SaveChangesAsync());
        }
    }
}
