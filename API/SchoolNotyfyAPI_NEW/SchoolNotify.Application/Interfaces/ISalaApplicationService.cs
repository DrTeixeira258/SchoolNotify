using SchoolNotify.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Interfaces
{
    public interface ISalaApplicationService
    {
        Task<IEnumerable<SalaViewModel>> ObterSalas();
        Task<SalaViewModel> ObterSalaPorId(int idSala);
        Task<bool> SalvarSala(SalaViewModel salaVM);
        Task<bool> DeletarSala(SalaViewModel salaVM);
    }
}
