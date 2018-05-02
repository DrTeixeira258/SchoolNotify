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
    public class NotificacaoApplicationService : BaseApplicationService, INotificacaoApplicationService
    {
        private readonly INotificacaoRepository _notificacaoRepository;

        public NotificacaoApplicationService(INotificacaoRepository notificacaoRepository)
        {
            _notificacaoRepository = notificacaoRepository;
        }

        public async Task<IEnumerable<NotificacaoViewModel>> ObterNotificacoes()
        {
            var notificacoesBD = await _notificacaoRepository.GetAllReadOnly(new[] { "Professor" });
            var notificacoesVM = Mapper.Map<IEnumerable<NotificacaoViewModel>>(notificacoesBD);

            //foreach (var notificacao in notificacoesVM)
            //{
            //    notificacao.Professor.Notificacoes = null;
            //    notificacao.Sala.Notificacoes = null;
            //    notificacao.Aluno.Notificacoes = null;
            //}

            return notificacoesVM;
        }

        public async Task<bool> SalvarNotificacoes(NotificacaoViewModel notificacaoVM)
        {
            try
            {
                var notificacaoBD = Mapper.Map<Notificacao>(notificacaoVM);
                notificacaoBD.Data = DateTime.Now.Date;
                await BeginTransaction();
                await Task.Run(() => _notificacaoRepository.Add(notificacaoBD));
                await Commit();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
