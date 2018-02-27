using AutoMapper;
using SchoolNotify.Application.Interfaces;
using SchoolNotify.Application.Services.Base;
using SchoolNotify.Application.ViewModels;
using SchoolNotify.Domain.Entities;
using SchoolNotify.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Services
{
    public class SalaApplicationService : BaseApplicationService, ISalaApplicationService
    {
        private readonly ISalaRepository _salaRepository;
        private readonly ISalaProfessorRelacionalRepository _salaProfessorRelacionalRepository;
        private readonly IAlunoRepository _alunoRepository;

        public SalaApplicationService(ISalaRepository salaRepository,
                                      ISalaProfessorRelacionalRepository salaProfessorRelacionalRepository,
                                      IAlunoRepository alunoRepository)
        {
            _salaRepository = salaRepository;
            _salaProfessorRelacionalRepository = salaProfessorRelacionalRepository;
            _alunoRepository = alunoRepository;
        }

        public async Task<IEnumerable<SalaViewModel>> ObterSalas()
        {
            var salaDB = await _salaRepository.GetAllReadOnly(new[] { "SalaProfessorRelacional" });
            var salasVM = Mapper.Map<IEnumerable<SalaViewModel>>(salaDB);
            List<int> idsProfessores = new List<int>();

            for (int i = 0; i < salasVM.ToList().Count; i++)
            {
                foreach (var sala in salaDB.ElementAt(i).SalaProfessorRelacional)
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
            var salaVM = Mapper.Map<SalaViewModel>(salaDB.FirstOrDefault());
            List<int> idsProfessores = new List<int>();

            foreach (var sala in salaDB.FirstOrDefault().SalaProfessorRelacional)
            {
                idsProfessores.Add(sala.IdProfessor);
            }
            salaVM.IdsProfessores = idsProfessores;
            return salaVM;
        }

        public async Task<IEnumerable<SalaViewModel>> ObterSalasComProfessores()
        {
            var relacionais = await _salaProfessorRelacionalRepository.GetAllReadOnly(new[] { "Sala" });
            var salas = relacionais.Select(x => x.Sala).Distinct(new SalasComparer());
            List<SalaViewModel> salasVM = new List<SalaViewModel>();

            foreach (var sala in salas)
            {
                salasVM.Add(Mapper.Map<SalaViewModel>(sala));
            }

            return salasVM;
        }

        public async Task<bool> SalvarSala(SalaViewModel salaVM)
        {
            try
            {
                var sala = Mapper.Map<Sala>(salaVM);
                var idsProfessores = salaVM.IdsProfessores;
                //Salvar Sala
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
                //Deletar SalaProfessorRelacional
                var salasProfessoresRalacionais = await _salaProfessorRelacionalRepository.Get(x => x.IdSala == sala.Id);
                foreach (var relacional in salasProfessoresRalacionais)
                {
                    await BeginTransaction();
                    await Task.Run(() => _salaProfessorRelacionalRepository.Delete(relacional));
                    await Commit();
                }
                //Inserir SalaProfessorRelacional
                foreach (int idProfessor in idsProfessores)
                {
                    SalaProfessorRelacional salaProfessor = new SalaProfessorRelacional
                    {
                        IdProfessor = idProfessor,
                        IdSala = sala.Id
                    };
                    await BeginTransaction();
                    await Task.Run(() => _salaProfessorRelacionalRepository.Add(salaProfessor));
                    await Commit();
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
                if (await ValidarExcluirSala(sala.Id))
                {
                    var relacionais = await _salaProfessorRelacionalRepository.Get(x => x.IdSala == sala.Id);

                    foreach (var relacional in relacionais)
                    {
                        await BeginTransaction();
                        await Task.Run(() => _salaProfessorRelacionalRepository.Delete(relacional));
                        await Commit();
                    }

                    await BeginTransaction();
                    await Task.Run(() => _salaRepository.Delete(sala));
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

        public async Task<bool> ValidarExcluirSala(int idSala)
        {
            var alunos = await _alunoRepository.Get(x => x.IdSala == idSala);
            if (!alunos.Any())
            {
                return true;
            }
            return false;
        }
    }

    public class SalasComparer : IEqualityComparer<Sala>
    {
        public bool Equals(Sala x, Sala y)
        {
            if (x.Id == y.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Sala obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
