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
    public class AlunoController : ApiController
    {
        private readonly IAlunoApplicationService _alunoAppService;

        public AlunoController(IAlunoApplicationService alunoAppService)
        {
            _alunoAppService = alunoAppService;
        }

        [HttpGet]
        [Route("Aluno/ObterTodos")]
        [ResponseType(typeof(IEnumerable<AlunoViewModel>))]
        public async Task<IHttpActionResult> GetObterTodos()
        {
            try
            {
                return Ok(await _alunoAppService.ObterAlunos());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("Aluno/ObterAlunoPorId/{idAluno}")]
        [ResponseType(typeof(AlunoViewModel))]
        public async Task<IHttpActionResult> ObterAlunoPorId(int idAluno)
        {
            try
            {
                return Ok(await _alunoAppService.ObterAlunoPorId(idAluno));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("Aluno/SalvarAluno")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> SalvarAluno(AlunoViewModel aluno)
        {
            try
            {
                return Ok(await _alunoAppService.SalvarAluno(aluno));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("Aluno/DeletarAluno")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeletarAluno(AlunoViewModel aluno)
        {
            try
            {
                return Ok(await _alunoAppService.DeletarAluno(aluno));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}