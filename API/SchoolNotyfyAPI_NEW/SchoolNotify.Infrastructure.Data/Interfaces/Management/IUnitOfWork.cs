using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Infrastructure.Data.Interfaces.Management
{
    public interface IUnitOfWork
    {
        Task BeginTransaction();
        Task SaveChangesAsync();
    }
}
