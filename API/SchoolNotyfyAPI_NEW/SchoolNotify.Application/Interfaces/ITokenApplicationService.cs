using SchoolNotify.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Interfaces
{
    public interface ITokenApplicationService
    {
        Task<bool> SalvarToken(TokenViewModel token);
        Task<IEnumerable<string>> BuscarTokensPorTelefones(IEnumerable<long> telefones);
    }
}
