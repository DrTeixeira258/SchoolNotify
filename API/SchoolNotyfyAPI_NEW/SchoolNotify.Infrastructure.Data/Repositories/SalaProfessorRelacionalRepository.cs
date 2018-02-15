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
    public class SalaProfessorRelacionalRepository : BaseRepository<SalaProfessorRelacional>, ISalaProfessorRelacionalRepository
    {
        public async Task<SalaProfessorRelacional> ObterSalaProfessorRelacionalPorIdSalaEProfessor(int idSala, int idProfessor)
        {
            var result = await Get(x => x.IdSala == idSala && x.IdProfessor == idProfessor);
            return result.FirstOrDefault();
        }
    }
}
