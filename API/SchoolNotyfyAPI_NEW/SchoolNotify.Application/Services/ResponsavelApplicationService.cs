﻿using AutoMapper;
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
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public ResponsavelApplicationService(IResponsavelRepository responsavelRepository,
                                             IAlunoRepository alunoRepository,
                                             IUsuarioApplicationService usuarioApplicationService)
        {
            _responsavelRepository = responsavelRepository;
            _alunoRepository = alunoRepository;
            _usuarioApplicationService = usuarioApplicationService;
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
                if (responsavel.Id == 0)
                {
                    await BeginTransaction();
                    await Task.Run(() => _responsavelRepository.Add(responsavel));
                    await Commit();
                    await _usuarioApplicationService.ValidarExistenciaUsuario(responsavel.Telefone, "Responsavel");
                }
                else
                {
                    await BeginTransaction();
                    await Task.Run(() => _responsavelRepository.Update(responsavel));
                    await Commit();
                }
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
                if (await ValidarDeletarResponsavel(responsavel.Id))
                {
                    await _usuarioApplicationService.ValidarExclusaoUsuario(responsavel.Telefone);

                    await BeginTransaction();
                    await Task.Run(() => _responsavelRepository.Delete(responsavel));
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

        public async Task<bool> ValidarDeletarResponsavel(int responsavelId)
        {
            var alunos = await _alunoRepository.Get(x => x.IdResponsavel == responsavelId);
            if (!alunos.Any())
            {
                return true;
            }
            return false;
        }
    }
}
