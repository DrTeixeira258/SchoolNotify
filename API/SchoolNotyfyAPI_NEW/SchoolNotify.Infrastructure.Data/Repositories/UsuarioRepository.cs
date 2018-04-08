using SchoolNotify.Domain.Entities;
using SchoolNotify.Domain.Interfaces.Repository;
using SchoolNotify.Infrastructure.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public async Task<Usuario> Logar(Usuario usuario)
        {
            try
            {
                var result = (await GetReadOnly(x => x.Login == usuario.Login && x.Senha == usuario.Senha)).FirstOrDefault();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
