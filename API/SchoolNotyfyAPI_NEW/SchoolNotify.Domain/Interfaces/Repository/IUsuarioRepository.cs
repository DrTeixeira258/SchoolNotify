using SchoolNotify.Domain.Entities;
using SchoolNotify.Domain.Interfaces.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<bool> Logar(Usuario usuario);
    }
}
