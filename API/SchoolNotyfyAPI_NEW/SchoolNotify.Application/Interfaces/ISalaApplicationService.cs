using SchoolNotify.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Interfaces
{
    public interface ISalaApplicationService
    {
        Task<IEnumerable<SalaViewModel>> ObterSalas();
    }
}
