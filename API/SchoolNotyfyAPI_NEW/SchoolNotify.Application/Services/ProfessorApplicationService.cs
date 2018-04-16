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
        private readonly ISalaProfessorRelacionalRepository _salaProfessorRelacionalRepository;
        private readonly ISalaApplicationService _salaApplicationService;
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public ProfessorApplicationService(IProfessorRepository professorRepository,
                                           ISalaProfessorRelacionalRepository salaProfessorRelacionalRepository,
                                           ISalaApplicationService salaApplicationService,
                                           IUsuarioApplicationService usuarioApplicationService)
        {
            _professorRepository = professorRepository;
            _salaProfessorRelacionalRepository = salaProfessorRelacionalRepository;
            _salaApplicationService = salaApplicationService;
            _usuarioApplicationService = usuarioApplicationService;
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
                if (professor.Id == 0)
                {
                    await BeginTransaction();
                    await Task.Run(() => _professorRepository.Add(professor));
                    await Commit();
                    await _usuarioApplicationService.ValidarExistenciaUsuario(professor.Telefone, "Professor");
                }
                else
                {
                    await BeginTransaction();
                    await Task.Run(() => _professorRepository.Update(professor));
                    await Commit();
                }
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
                var relacionais = await _salaProfessorRelacionalRepository.Get(x => x.IdProfessor == professor.Id, new[] { "Sala" });
                if (await ValidarDeletarProfessor(professor, relacionais))
                {
                    await _usuarioApplicationService.ValidarExclusaoUsuario(professor.Telefone, "P");

                    foreach (var relacional in relacionais)
                    {
                        await BeginTransaction();
                        await Task.Run(() => _salaProfessorRelacionalRepository.Delete(relacional));
                        await Commit();
                    }

                    await BeginTransaction();
                    await Task.Run(() => _professorRepository.Delete(professor));
                    await Commit();

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ValidarDeletarProfessor(Professor professor, IEnumerable<SalaProfessorRelacional> relacionais)
        {
            var salas = relacionais.Select(x => x.Sala).Distinct(new SalasComparer());

            foreach (var sala in salas)
            {
                if (!await _salaApplicationService.ValidarExcluirSala(sala.Id))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
