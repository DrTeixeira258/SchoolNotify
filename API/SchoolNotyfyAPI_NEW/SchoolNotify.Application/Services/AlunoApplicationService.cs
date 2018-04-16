using AutoMapper;
using SchoolNotify.Application.Interfaces;
using SchoolNotify.Application.Services.Base;
using SchoolNotify.Application.ViewModels;
using SchoolNotify.Domain.Entities;
using SchoolNotify.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Services
{
    public class AlunoApplicationService : BaseApplicationService, IAlunoApplicationService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;

        public AlunoApplicationService(IAlunoRepository alunoRepository, IProfessorRepository professorRepository)
        {
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
        }

        public async Task<IEnumerable<AlunoViewModel>> ObterAlunos()
        {
            var alunos = await _alunoRepository.GetAllReadOnly(new[] { "Sala","Responsavel" });
            foreach (var aluno in alunos)
            {
                aluno.Responsavel.Alunos = null;
                aluno.Sala.Alunos = null;
            }
            
            return Mapper.Map<IEnumerable<AlunoViewModel>>(alunos);
        }

        public async Task<IEnumerable<AlunoViewModel>> ObterAlunosPorProfessor(int idProfessor)
        {
            var alunos = (await _professorRepository.GetReadOnly(x => x.Id == idProfessor, new string[] { "SalaProfessorRelacional.Sala", "SalaProfessorRelacional.Sala.Alunos" })).FirstOrDefault()
                .SalaProfessorRelacional.Select(y => y.Sala).SelectMany(z => z.Alunos);
            var alunosVM = Mapper.Map<IEnumerable<AlunoViewModel>>(alunos);
            return alunosVM;
        }

        public async Task<AlunoViewModel> ObterAlunoPorId(int idAluno)
        {
            return Mapper.Map<AlunoViewModel>(await _alunoRepository.GetById(idAluno));
        }

        public async Task<bool> SalvarAluno(AlunoViewModel alunoVM)
        {
            try
            {
                Aluno aluno = Mapper.Map<Aluno>(alunoVM);
                aluno.Sala = null;
                aluno.Responsavel = null;

                await BeginTransaction();
                if (aluno.Id == 0)
                {
                    await Task.Run(() => _alunoRepository.Add(aluno));
                }
                else
                {
                    await Task.Run(() => _alunoRepository.Update(aluno));
                }
                await Commit();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeletarAluno(AlunoViewModel alunoVM)
        {
            try
            {
                var aluno = Mapper.Map<Aluno>(alunoVM);

                await BeginTransaction();
                await Task.Run(() => _alunoRepository.Delete(aluno));
                await Commit();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
