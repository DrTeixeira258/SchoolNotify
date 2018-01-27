using Domain.Entities;
using SchoolNotify.Domain.Interfaces.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Domain.Interfaces.Repository
{
    public interface ICelulaUnidadeRelacionalRepository : IBaseRepository<CelulaUnidadeRelacional>
    {
        Task<ICollection<CelulaUnidadeRelacional>> BuscarCelulaUnidadeRelacionalPorUnidade(int unidadeId);
        Task<CelulaUnidadeRelacional> BuscarCelulaUnidadeRelacionalPorCelulaUnidade(int celulaId, int unidadeId);
        Task<ICollection<CelulaUnidadeRelacional>> BuscarCelulaUnidadeRelacionalPorCelula(int celulaId);
    }
}
