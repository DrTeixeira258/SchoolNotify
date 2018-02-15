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

        public AlunoApplicationService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<IEnumerable<AlunoViewModel>> ObterAlunos()
        {
            return Mapper.Map<IEnumerable<AlunoViewModel>>(await _alunoRepository.GetAll());
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
