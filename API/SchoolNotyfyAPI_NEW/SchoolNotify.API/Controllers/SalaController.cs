using SchoolNotify.Application.Interfaces;
using SchoolNotify.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SchoolNotify.API.Controllers
{
    [RoutePrefix("api")]

    public class SalaController : ApiController
    {
        private readonly ISalaApplicationService _salaAppService;

        public SalaController(ISalaApplicationService salaAppService)
        {
            _salaAppService = salaAppService;
        }

        [HttpGet]
        [Route("Sala/ObterTodas")]
        [ResponseType(typeof(IEnumerable<SalaViewModel>))]
        public async Task<IHttpActionResult> GetObterTodas()
        {
            try
            {
                return Ok(await _salaAppService.ObterSalas());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("Sala/ObterSalaPorId/{idSala}")]
        [ResponseType(typeof(SalaViewModel))]
        public async Task<IHttpActionResult> ObterSalaPorId(int idSala)
        {
            try
            {
                return Ok(await _salaAppService.ObterSalaPorId(idSala));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("Sala/ObterSalasComProfessores")]
        [ResponseType(typeof(IEnumerable<SalaViewModel>))]
        public async Task<IHttpActionResult> ObterSalasComProfessores()
        {
            try
            {
                return Ok(await _salaAppService.ObterSalasComProfessores());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("Sala/ObterSalasPorIdProfessor/{idProfessor}")]
        [ResponseType(typeof(IEnumerable<SalaViewModel>))]
        public async Task<IHttpActionResult> ObterSalasPorIdProfessor(int idProfessor)
        {
            try
            {
                return Ok(await _salaAppService.ObterSalasPorIdProfessor(idProfessor));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("Sala/SalvarSala")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> SalvarSala(SalaViewModel sala)
        {
            try
            {
                return Ok(await _salaAppService.SalvarSala(sala));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("Sala/DeletarSala")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeletarSala(SalaViewModel sala)
        {
            try
            {
                return Ok(await _salaAppService.DeletarSala(sala));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}