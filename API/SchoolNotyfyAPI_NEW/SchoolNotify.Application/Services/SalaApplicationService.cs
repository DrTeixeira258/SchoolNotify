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

        public SalaApplicationService(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public async Task<IEnumerable<SalaViewModel>> ObterSalas()
        {
            return Mapper.Map<IEnumerable<SalaViewModel>>(await _salaRepository.GetAll());
        }

        public async Task<SalaViewModel> ObterSalaPorId(int idSala)
        {
            return Mapper.Map<SalaViewModel>(await _salaRepository.GetById(idSala));
        }

        public async Task<bool> SalvarSala(SalaViewModel salaVM)
        {
            try
            {
                var sala = Mapper.Map<Sala>(salaVM);
                await BeginTransaction();
                if (sala.Id == 0)
                {
                    await Task.Run(() => _salaRepository.Add(sala));
                }
                else
                {
                    await Task.Run(() => _salaRepository.Update(sala));
                }
                await Commit();
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
