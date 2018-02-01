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
    public class ProfessorController : ApiController
    {
        private readonly IProfessorApplicationService _professorAppService;

        public ProfessorController(IProfessorApplicationService professorAppService)
        {
            _professorAppService = professorAppService;
        }

        [HttpGet]
        [Route("Professor/ObterTodos")]
        [ResponseType(typeof(IEnumerable<ProfessorViewModel>))]
        public async Task<IHttpActionResult> GetObterTodos()
        {
            try
            {
                return Ok(await _professorAppService.ObterProfessores());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("Professor/ObterProfessorPorId/{idProfessor}")]
        [ResponseType(typeof(ProfessorViewModel))]
        public async Task<IHttpActionResult> ObterProfessorPorId(int idProfessor)
        {
            try
            {
                return Ok(await _professorAppService.ObterProfessorPorId(idProfessor));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("Professor/SalvarProfessor")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> SalvarProfessor(ProfessorViewModel professor)
        {
            try
            {
                return Ok(await _professorAppService.SalvarProfessor(professor));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("Professor/DeletarProfessor")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeletarProfessor(ProfessorViewModel professor)
        {
            try
            {
                return Ok(await _professorAppService.DeletarProfessor(professor));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}