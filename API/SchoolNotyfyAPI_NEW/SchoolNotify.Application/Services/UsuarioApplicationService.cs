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

        public UsuarioApplicationService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Logar(UsuarioViewModel usuario)
        {
            return await _usuarioRepository.Logar(Mapper.Map<Usuario>(usuario));
        }

        public async Task<bool> Cadastrar(UsuarioViewModel usuarioVM)
        {
            var usuario = Mapper.Map<Usuario>(usuarioVM);
            var responsavel = await _responsavelRepository.GetReadOnly(x => x.Telefone == usuario.Telefone);
            var professor = await _professorRepository.GetReadOnly(x => x.Telefone == usuario.Telefone);
            if (professor.Any())
                usuario.Professor = true;
            if (responsavel.Any())
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

        public async Task ValidarExclusaoUsuario(int telefone)
        {
            int perfis = 0;
            var usuario = (await _usuarioRepository.GetReadOnly(x => x.Telefone == telefone)).FirstOrDefault();

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
        }

        public async Task ValidarExistenciaUsuario(int telefone, string perfil)
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
