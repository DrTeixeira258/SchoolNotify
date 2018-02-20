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
    public class SalaApplicationService : BaseApplicationService, ISalaApplicationService
    {
        private readonly ISalaRepository _salaRepository;
        private readonly ISalaProfessorRelacionalRepository _salaProfessorRelacionalRepository;

        public SalaApplicationService(ISalaRepository salaRepository,
                                      ISalaProfessorRelacionalRepository salaProfessorRelacionalRepository)
        {
            _salaRepository = salaRepository;
            _salaProfessorRelacionalRepository = salaProfessorRelacionalRepository;
        }

        public async Task<IEnumerable<SalaViewModel>> ObterSalas()
        {
            var salaDB = await _salaRepository.GetAllReadOnly(new[] { "SalaProfessorRelacional" });
            var salasVM = Mapper.Map<IEnumerable<SalaViewModel>>(salaDB);
            List<int> idsProfessores = new List<int>();

            for (int i = 0; i < salasVM.ToList().Count; i++)
            {
                foreach(var sala in salaDB.ElementAt(i).SalaProfessorRelacional)
                {
                    idsProfessores.Add(sala.IdProfessor);
                }
                salasVM.ElementAt(i).IdsProfessores = idsProfessores;
                idsProfessores = new List<int>();
            }
            return salasVM;
        }

        public async Task<SalaViewModel> ObterSalaPorId(int idSala)
        {
            var salaDB = await _salaRepository.Get(x => x.Id == idSala, new[] { "SalaProfessorRelacional" });
            var salaVM =  Mapper.Map<SalaViewModel>(salaDB.FirstOrDefault());
            List<int> idsProfessores = new List<int>();

            foreach (var sala in salaDB.FirstOrDefault().SalaProfessorRelacional)
            {
                idsProfessores.Add(sala.IdProfessor);
            }
            salaVM.IdsProfessores = idsProfessores;
            return salaVM;
        }

        public async Task<bool> SalvarSala(SalaViewModel salaVM)
        {
            try
            {
                var sala = Mapper.Map<Sala>(salaVM);
                var idsProfessores = salaVM.IdsProfessores;

                await BeginTransaction();
                if (sala.Id == 0)
                {
                    sala = await Task.Run(() => _salaRepository.AddReturn(sala));
                }
                else
                {
                    await Task.Run(() => _salaRepository.Update(sala));
                }
                await Commit();

                foreach (int idProfessor in idsProfessores)
                {
                    SalaProfessorRelacional salaProfessor = await _salaProfessorRelacionalRepository.ObterSalaProfessorRelacionalPorIdSalaEProfessor(sala.Id, idProfessor);
                    if (salaProfessor == null)
                    {
                        salaProfessor.IdProfessor = idProfessor;
                        salaProfessor.IdSala = sala.Id;
                        await BeginTransaction();
                        await Task.Run(() => _salaProfessorRelacionalRepository.Add(salaProfessor));
                        await Commit();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<bool> DeletarSala(SalaViewModel salaVM)
        {
            try
            {
                var sala = Mapper.Map<Sala>(salaVM);

                await BeginTransaction();
                await Task.Run(() => _salaRepository.Delete(sala));
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
