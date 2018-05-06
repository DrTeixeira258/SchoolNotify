using SchoolNotify.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Interfaces
{
    public interface IAlunoApplicationService
    {
        Task<IEnumerable<AlunoViewModel>> ObterAlunos();
        Task<IEnumerable<AlunoViewModel>> ObterAlunosPorProfessor(int idProfessor);
        Task<AlunoViewModel> ObterAlunoPorId(int idAluno);
        Task<bool> SalvarAluno(AlunoViewModel alunoVM);
        Task<bool> DeletarAluno(AlunoViewModel alunoVM);
        Task<IEnumerable<AlunoViewModel>> ObterAlunoPorResponsavel(int idResponsavel);
    }
}
