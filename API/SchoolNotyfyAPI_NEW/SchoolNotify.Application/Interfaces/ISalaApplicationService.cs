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
        Task<IEnumerable<SalaViewModel>> ObterSalasPorAlunos(IEnumerable<AlunoViewModel> alunos);
        Task<SalaViewModel> ObterSalaPorId(int idSala);
        Task<IEnumerable<SalaViewModel>> ObterSalasComProfessores();
        Task<IEnumerable<SalaViewModel>> ObterSalasPorIdProfessor(int idProfessor);
        Task<bool> SalvarSala(SalaViewModel salaVM);
        Task<bool> DeletarSala(SalaViewModel salaVM);
        Task<bool> ValidarExcluirSala(int idSala);
    }
}
