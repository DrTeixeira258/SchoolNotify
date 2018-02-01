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
    public class ProfessorApplicationService : BaseApplicationService, IProfessorApplicationService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorApplicationService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<IEnumerable<ProfessorViewModel>> ObterProfessores()
        {
            return Mapper.Map<IEnumerable<ProfessorViewModel>>(await _professorRepository.GetAll());
        }

        public async Task<ProfessorViewModel> ObterProfessorPorId(int idProfessor)
        {
            return Mapper.Map<ProfessorViewModel>(await _professorRepository.GetById(idProfessor));
        }

        public async Task<bool> SalvarProfessor(ProfessorViewModel professorVM)
        {
            try
            {
                var professor = Mapper.Map<Professor>(professorVM);
                await BeginTransaction();
                if (professor.Id == 0)
                {
                    await Task.Run(() => _professorRepository.Add(professor));
                }
                else
                {
                    await Task.Run(() => _professorRepository.Update(professor));
                }
                await Commit();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<bool> DeletarProfessor(ProfessorViewModel professorVM)
        {
            try
            {
                var professor = Mapper.Map<Professor>(professorVM);

                await BeginTransaction();
                await Task.Run(() => _professorRepository.Delete(professor));
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
