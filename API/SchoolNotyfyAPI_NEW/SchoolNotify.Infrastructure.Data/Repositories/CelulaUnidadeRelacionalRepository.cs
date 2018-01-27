using Domain.Entities;
using SchoolNotify.Domain.Interfaces.Repository;
using SchoolNotify.Infrastructure.Data.Repositories.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Infrastructure.Data.Repositories
{
    public class CelulaUnidadeRelacionalRepository : BaseRepository<CelulaUnidadeRelacional>, ICelulaUnidadeRelacionalRepository
    {
        public async Task<ICollection<CelulaUnidadeRelacional>> BuscarCelulaUnidadeRelacionalPorUnidade(int unidadeId)
        {
            var celulasUnidades = await GetWithTracking(x => x.UnidadeId == unidadeId);
            return celulasUnidades.ToList();
        }

        public async Task<ICollection<CelulaUnidadeRelacional>> BuscarCelulaUnidadeRelacionalPorCelula(int celulaId)
        {
            var celulasUnidades = await GetWithTracking(x => x.CelulaId == celulaId);
            return celulasUnidades.ToList();
        }

        public async Task<CelulaUnidadeRelacional> BuscarCelulaUnidadeRelacionalPorCelulaUnidade(int celulaId,int unidadeId)
        {
            var celulasUnidades = await Get(x => x.UnidadeId == unidadeId && x.CelulaId == celulaId);
            return celulasUnidades.FirstOrDefault();
        }
    }
}
