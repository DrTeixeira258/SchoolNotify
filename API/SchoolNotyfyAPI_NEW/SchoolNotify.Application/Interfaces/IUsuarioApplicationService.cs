using SchoolNotify.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        Task<bool> Logar(UsuarioViewModel usuario);
        Task<bool> Cadastrar(UsuarioViewModel usuarioVM);
        Task ValidarExclusaoUsuario(int telefone);
        Task ValidarExistenciaUsuario(int telefone, string perfil);
    }
}
