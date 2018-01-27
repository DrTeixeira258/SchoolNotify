using AutoMapper;
using Domain.Entities;
using SchoolNotify.Application.Interfaces;
using SchoolNotify.Application.Services.Base;
using SchoolNotify.Application.ViewModels;
using SchoolNotify.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Services
{
    public class CelulaApplicationService : BaseApplicationService, ICelulaApplicationService
    {
        private readonly ICelulaRepository _celulaRepository;
        private readonly ICelulaUnidadeRelacionalRepository _celulaUnidadeRelacionalRepository;

        public CelulaApplicationService(ICelulaRepository celulaRepository, 
                                        ICelulaUnidadeRelacionalRepository celulaUnidadeRelacionalRepository)
        {
            _celulaRepository = celulaRepository;
            _celulaUnidadeRelacionalRepository = celulaUnidadeRelacionalRepository;
        }

        //public async Task<IEnumerable<DropDownItemViewModel>> PreencherComboCelula()
        //{
        //    return Mapper.Map<IEnumerable<DropDownItemViewModel>>(await _celulaRepository.BuscarCelulasValidas());
        //}

        //public async Task<CelulaViewModel> ObterCelula(int id)
        //{
        //    return Mapper.Map<CelulaViewModel>(await _celulaRepository.GetById(id));
        //}

        //public async Task<IEnumerable<DropDownItemViewModel>> ObterCelulaUnidade(int id)
        //{
        //    return Mapper.Map<IEnumerable<DropDownItemViewModel>>(await _celulaRepository.BuscarCelulasPorUnidade(id));
        //}
        
        public async Task EditarCelula(CelulaViewModel celulaVM)
        {
            Celula celula = Mapper.Map<Celula>(celulaVM);
            await BeginTransaction();
            await Task.Run(() => _celulaRepository.Update(celula));
            await Commit();
        }

        public async Task PersistirCelula(CelulaViewModel celulaVM)
        {
            Celula celula = Mapper.Map<Celula>(celulaVM);
            await BeginTransaction();

            await Task.Run(() => _celulaRepository.Add(celula));

            await Commit();
        }

        public async Task RemoverCelula(int id)
        {
            //await BeginTransaction();

            //await _celulaService.RemoverCelula(id);

            //await Commit();
        }

        //public async Task<bool> VerificaExistenciaColaboradores(int id)
        //{
            //var celula = await _celulaRepository.GetById(id);
            //var result = celula.CelulaUnidadeRelacional.Any(x => x.Colaboradores.Any());
            //return result;
        //}

        //public async Task<bool> VerficaExistenciaGestor(int celulaId, int unidadeId)
        //{
            //var celulaUnidadeRelacional = await _celulaUnidadeRelacionalRepository.BuscarCelulaUnidadeRelacionalPorCelulaUnidade(celulaId, unidadeId);
            //var gestor = await _colaboradorRepository.BuscarGestorPorCelulaUnidade(celulaUnidadeRelacional.Id);
            //if (gestor != null)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        //}

        //public async Task<IEnumerable<DropDownItemViewModel>> ObterCelulasSupervisionadas(string login)
        //{
        //    var colaborador = await _colaboradorRepository.ObterColaboradorPorLogin(login);
        //    return Mapper.Map<IEnumerable<DropDownItemViewModel>>(await _celulaRepository.BuscarCelulasSupervisionadasPorColaborador(colaborador));
        //}
    }
}
