using SchoolNotify.Application.Interfaces;
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
    public class ResponsavelController : ApiController
    {
        private readonly IResponsavelApplicationService _responsavelAppService;

        public ResponsavelController(IResponsavelApplicationService responsavelAppService)
        {
            _responsavelAppService = responsavelAppService;
        }

        [HttpGet]
        [Route("Responsavel/ObterTodos")]
        [ResponseType(typeof(IEnumerable<ResponsavelViewModel>))]
        public async Task<IHttpActionResult> GetObterTodos()
        {
            try
            {
                return Ok(await _responsavelAppService.ObterResponsaveis());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("Responsavel/ObterResponsavelPorId/{idResponsavel}")]
        [ResponseType(typeof(ResponsavelViewModel))]
        public async Task<IHttpActionResult> ObterResponsavelPorId(int idResponsavel)
        {
            try
            {
                return Ok(await _responsavelAppService.ObterResponsavelPorId(idResponsavel));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("Responsavel/SalvarResponsavel")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> SalvarResponsavel(ResponsavelViewModel responsavel)
        {
            try
            {
                return Ok(await _responsavelAppService.SalvarResponsavel(responsavel));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("Responsavel/DeletarResponsavel")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeletarResponsavel(ResponsavelViewModel responsavel)
        {
            try
            {
                return Ok(await _responsavelAppService.DeletarResponsavel(responsavel));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        [HttpGet]
        [Route("Responsavel/BuscarTelefonesResponsaveis/{idSala}")]
        [ResponseType(typeof(IEnumerable<ResponsavelViewModel>))]
        public async Task<IHttpActionResult> BuscarTelefonesResponsaveis(int idSala)
        {
            try
            {
                return Ok(await _responsavelAppService.BuscarTelefonesResponsaveis(idSala));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("Responsavel/BuscarTelefoneResponsavel/{idAluno}")]
        [ResponseType(typeof(IEnumerable<ResponsavelViewModel>))]
        public async Task<IHttpActionResult> BuscarTelefoneResponsavel(int idAluno)
        {
            try
            {
                return Ok(await _responsavelAppService.BuscarTelefoneResponsavel(idAluno));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}