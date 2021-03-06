﻿using SchoolNotify.Application.Interfaces;
using SchoolNotify.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace SchoolNotify.API.Controllers
{
    [RoutePrefix("api")]
    public class NotificacaoController : ApiController
    {
        private readonly INotificacaoApplicationService _notificacaoAppService;

        public NotificacaoController(INotificacaoApplicationService notificacaoAppService)
        {
            _notificacaoAppService = notificacaoAppService;
        }

        [HttpGet]
        [Route("Notificacao/ObterTodas")]
        [ResponseType(typeof(IEnumerable<NotificacaoViewModel>))]
        public async Task<IHttpActionResult> ObterTodas()
        {
            try
            {
                return Ok(await _notificacaoAppService.ObterNotificacoes());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("Notificacao/BuscarNotificacoesResponsavel/{idResponsavel}")]
        [ResponseType(typeof(IEnumerable<NotificacaoViewModel>))]
        public async Task<IHttpActionResult> BuscarNotificacoesResponsavel(int idResponsavel)
        {
            try
            {
                return Ok(await _notificacaoAppService.BuscarNotificacoesResponsavel(idResponsavel));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("Notificacao/ObterNotificacaoPorId/{idNotificacao}")]
        [ResponseType(typeof(NotificacaoViewModel))]
        public async Task<IHttpActionResult> ObterNotificacaoPorId(int idNotificacao)
        {
            try
            {
                return Ok(await _notificacaoAppService.ObterNotificacaoPorId(idNotificacao));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("Notificacao/SalvarNotificacao")]
        [ResponseType(typeof(int))]
        public async Task<IHttpActionResult> SalvarNotificacao(NotificacaoViewModel notificacaoVM)
        {
            try
            {
                return Ok(await _notificacaoAppService.SalvarNotificacoes(notificacaoVM));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}