using Domain.Entities;
using SchoolNotify.Domain.Interfaces.Repository;
using SchoolNotify.Infrastructure.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Infrastructure.Data.Repositories
{
    public class CelulaRepository : BaseRepository<Celula>, ICelulaRepository
    {
        public async Task<IEnumerable<Celula>> BuscarCelulasPorUnidade(int id)
        {
            return await Get(x => x.CelulaUnidadeRelacional.Any(y => y.UnidadeId == id) && x.Cancelada != true);
        }

        public async Task<IEnumerable<Celula>> BuscarCelulasValidas()
        {
            return await Get(x => x.Cancelada != true);
        }
    }
}
