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
    public class ResponsavelApplicationService : BaseApplicationService, IResponsavelApplicationService
    {
        private readonly IResponsavelRepository _responsavelRepository;

        public ResponsavelApplicationService(IResponsavelRepository responsavelRepository)
        {
            _responsavelRepository = responsavelRepository;
        }

        public async Task<IEnumerable<ResponsavelViewModel>> ObterResponsaveis()
        {
            return Mapper.Map<IEnumerable<ResponsavelViewModel>>(await _responsavelRepository.GetAll());
        }

        public async Task<ResponsavelViewModel> ObterResponsavelPorId(int idResponsavel)
        {
            return Mapper.Map<ResponsavelViewModel>(await _responsavelRepository.GetById(idResponsavel));
        }

        public async Task<bool> SalvarResponsavel(ResponsavelViewModel responsavelVM)
        {
            try
            {
                var responsavel = Mapper.Map<Responsavel>(responsavelVM);
                await BeginTransaction();
                if (responsavel.Id == 0)
                {
                    await Task.Run(() => _responsavelRepository.Add(responsavel));
                }
                else
                {
                    await Task.Run(() => _responsavelRepository.Update(responsavel));
                }
                await Commit();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<bool> DeletarResponsavel(ResponsavelViewModel responsavelVM)
        {
            try
            {
                var responsavel = Mapper.Map<Responsavel>(responsavelVM);

                await BeginTransaction();
                await Task.Run(() => _responsavelRepository.Delete(responsavel));
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
