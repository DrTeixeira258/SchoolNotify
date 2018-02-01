using SchoolNotify.Domain.Entities;
using SchoolNotify.Domain.Interfaces.Repository;
using SchoolNotify.Infrastructure.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Infrastructure.Data.Repositories
{
    public class ResponsavelRepository : BaseRepository<Responsavel>, IResponsavelRepository
    {
    }
}
