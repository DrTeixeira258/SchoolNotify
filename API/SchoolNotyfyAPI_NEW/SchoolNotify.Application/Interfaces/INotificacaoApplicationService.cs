using SchoolNotify.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Interfaces
{
    public interface INotificacaoApplicationService
    {
        Task<IEnumerable<NotificacaoViewModel>> ObterNotificacoes();
        Task<bool> SalvarNotificacoes(NotificacaoViewModel notificacaoVM);
    }
}
