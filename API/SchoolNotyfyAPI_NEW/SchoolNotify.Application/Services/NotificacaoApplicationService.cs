using AutoMapper;
using SchoolNotify.Application.Interfaces;
using SchoolNotify.Application.Services.Base;
using SchoolNotify.Application.ViewModels;
using SchoolNotify.Domain.Entities;
using SchoolNotify.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolNotify.Application.Services
{
    public class NotificacaoApplicationService : BaseApplicationService, INotificacaoApplicationService
    {
        private readonly INotificacaoRepository _notificacaoRepository;
        private readonly IAlunoApplicationService _alunoService;
        private readonly ISalaApplicationService _salaService;

        public NotificacaoApplicationService(INotificacaoRepository notificacaoRepository,
                                             IAlunoApplicationService alunoService,
                                             ISalaApplicationService salaService)
        {
            _notificacaoRepository = notificacaoRepository;
            _alunoService = alunoService;
            _salaService = salaService;
        }

        public async Task<IEnumerable<NotificacaoViewModel>> ObterNotificacoes()
        {
            var notificacoesBD = await _notificacaoRepository.GetAllReadOnly(new string[] { "Professor" });
            var notificacoesVM = Mapper.Map<IEnumerable<NotificacaoViewModel>>(notificacoesBD);

            return notificacoesVM;
        }

        public async Task<NotificacaoViewModel> ObterNotificacaoPorId(int idNotificacao)
        {
            var notificacaoBD = (await _notificacaoRepository.Get(x => x.Id == idNotificacao)).FirstOrDefault();
            var notificacaoVM = Mapper.Map<NotificacaoViewModel>(notificacaoBD);

            return notificacaoVM;
        }

        public async Task<int> SalvarNotificacoes(NotificacaoViewModel notificacaoVM)
        {
            try
            {
                var notificacaoBD = Mapper.Map<Notificacao>(notificacaoVM);
                notificacaoBD.Data = DateTime.Now.Date;
                await BeginTransaction();
                var notificacao = await Task.Run(() => _notificacaoRepository.AddReturn(notificacaoBD));
                await Commit();
                return notificacao.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<NotificacaoViewModel>> BuscarNotificacoesResponsavel(int idResponsavel)
        {
            var alunosResp = await _alunoService.ObterAlunoPorResponsavel(idResponsavel);
            var salasAlunos = await _salaService.ObterSalasPorAlunos(alunosResp);
            var notificacoes = new List<Notificacao>();

            foreach (var aluno in alunosResp)
            {
                var notificacao = await _notificacaoRepository.GetReadOnly(x => x.IdAluno == aluno.Id, new string[] { "Aluno" });
                if (notificacao != null)
                    notificacoes.AddRange(notificacao);
            }

            foreach (var sala in salasAlunos)
            {
                var notificacao = await _notificacaoRepository.GetReadOnly(x => x.IdSala == sala.Id, new string[] { "Sala" });
                if (notificacao != null)
                    notificacoes.AddRange(notificacao);
            }

            var notificacaoesVM = Mapper.Map<IEnumerable<NotificacaoViewModel>>(notificacoes);
            return notificacaoesVM;
        }
    }
}
