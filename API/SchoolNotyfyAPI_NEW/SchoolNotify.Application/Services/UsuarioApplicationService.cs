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
    public class UsuarioApplicationService : BaseApplicationService, IUsuarioApplicationService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IResponsavelRepository _responsavelRepository;

        public UsuarioApplicationService(IUsuarioRepository usuarioRepository,
            IProfessorRepository professorRepository,
            IResponsavelRepository responsavelRepository)
        {
            _usuarioRepository = usuarioRepository;
            _professorRepository = professorRepository;
            _responsavelRepository = responsavelRepository;
        }

        public async Task<UsuarioViewModel> Logar(UsuarioViewModel usuarioVM)
        {
            var usuario = Mapper.Map<UsuarioViewModel>(await _usuarioRepository.Logar(Mapper.Map<Usuario>(usuarioVM)));
            if (usuario != null)
            {
                if (usuario.Professor == true)
                {
                    var professor = (await _professorRepository.GetReadOnly(x => x.Telefone == usuario.Telefone)).FirstOrDefault();
                    usuario.IdProfessor = professor.Id;
                    usuario.Nome = professor.Nome;
                }
                else if (usuario.Responsavel == true)
                {
                    var responsavel = (await _responsavelRepository.GetReadOnly(x => x.Telefone == usuario.Telefone)).FirstOrDefault();
                    usuario.IdResponsavel = responsavel.Id;
                    usuario.Nome = responsavel.Nome;
                }
                else
                {
                    usuario.Nome = "Administrador";
                }
                usuario.Senha = "";
                usuario.Login = "";
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Cadastrar(UsuarioViewModel usuarioVM)
        {
            if (await ValidarInsercao(usuarioVM))
            {
                var usuario = Mapper.Map<Usuario>(usuarioVM);
                var responsavel = await _responsavelRepository.GetReadOnly(x => x.Telefone == usuario.Telefone);
                var professor = await _professorRepository.GetReadOnly(x => x.Telefone == usuario.Telefone);
                if (professor.Any())
                    usuario.Professor = true;
                else if (responsavel.Any())
                    usuario.Responsavel = true;

                if (usuario.Professor == true || usuario.Responsavel == true)
                {
                    await BeginTransaction();
                    await Task.Run(() => _usuarioRepository.Add(usuario));
                    await Commit();
                    return true;
                }
                return false;
            }
            return false;
        }

        private async Task<bool> ValidarInsercao(UsuarioViewModel usuarioVM)
        {
            var usuarioDB = await _usuarioRepository.GetReadOnly(x => x.Telefone == usuarioVM.Telefone);
            if (usuarioDB.Any())
                return false;
            return true;
        }

        public async Task ValidarExclusaoUsuario(long telefone, string perfil)
        {
            int perfis = 0;
            var usuario = (await _usuarioRepository.GetReadOnly(x => x.Telefone == telefone)).FirstOrDefault();

            if (usuario != null)
            {
                if (usuario.Professor == true)
                    perfis++;
                if (usuario.Responsavel == true)
                    perfis++;

                if (perfis == 1)
                {
                    await BeginTransaction();
                    await Task.Run(() => _usuarioRepository.Delete(usuario));
                    await Commit();
                }
                else
                {
                    if (perfil == "P")
                        usuario.Professor = false;
                    else
                        usuario.Responsavel = false;

                    await BeginTransaction();
                    await Task.Run(() => _usuarioRepository.Update(usuario));
                    await Commit();
                }
            }
        }

        public async Task ValidarExistenciaUsuario(long telefone, string perfil)
        {
            var usuarios = (await _usuarioRepository.Get(x => x.Telefone == telefone));
            var usuario = new Usuario();
            if (usuarios.Any() == true)
            {
                usuario = usuarios.FirstOrDefault();
                if (perfil == "Responsavel")
                {
                    if (usuario.Responsavel == false)
                        usuario.Responsavel = true;
                }
                else
                {
                    if (usuario.Professor == false)
                        usuario.Professor = true;
                }

                await BeginTransaction();
                await Task.Run(() => _usuarioRepository.Update(usuario));
                await Commit();
            }
        }
    }
}
