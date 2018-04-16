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
        Task<UsuarioViewModel> Logar(UsuarioViewModel usuario);
        Task<bool> Cadastrar(UsuarioViewModel usuarioVM);
        Task ValidarExclusaoUsuario(long telefone, string perfil);
        Task ValidarExistenciaUsuario(long telefone, string perfil);
    }
}
