using Domain.Entities;
using SchoolNotify.Domain.Interfaces.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Domain.Interfaces.Repository
{
    public interface ICelulaRepository : IBaseRepository<Celula>
    {
        Task<IEnumerable<Celula>> BuscarCelulasPorUnidade(int id);
        Task<IEnumerable<Celula>> BuscarCelulasValidas();
    }
}
