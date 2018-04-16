using SchoolNotify.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Interfaces
{
    public interface IResponsavelApplicationService
    {
        Task<IEnumerable<ResponsavelViewModel>> ObterResponsaveis();
        Task<ResponsavelViewModel> ObterResponsavelPorId(int idResponsavel);
        Task<bool> SalvarResponsavel(ResponsavelViewModel responsavelVM);
        Task<bool> DeletarResponsavel(ResponsavelViewModel responsavelVM);
        Task<IEnumerable<long>> BuscarTelefonesResponsaveis(int idSala);
        Task<long> BuscarTelefoneResponsavel(int idAluno);
    }
}
