using SchoolNotify.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Interfaces
{
    public interface IProfessorApplicationService
    {
        Task<IEnumerable<ProfessorViewModel>> ObterProfessores();
        Task<ProfessorViewModel> ObterProfessorPorId(int idProfessor);
        Task<bool> SalvarProfessor(ProfessorViewModel professorVM);
        Task<bool> DeletarProfessor(ProfessorViewModel professorVM);
    }
}
