//using SchoolNotify.Application.Interfaces;
//using SchoolNotify.Application.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Description;

//namespace SchoolNotify.Controllers
//{
//    [RoutePrefix("api")]

//    public class CelulaController : ApiController
//    {
//        private readonly ICelulaApplicationService _celulaAppService;

//         public CelulaController(ICelulaApplicationService celulaAppService)
//        {
//            _celulaAppService = celulaAppService;
//        }

//        [HttpPost]
//        [Route("Celula/SalvarCelula")]
//        public async Task<IHttpActionResult> PostSalvarCelula(CelulaViewModel celula)
//        {
//            if (celula == null)
//                return BadRequest();
//            try
//            {
//                //await _celulaAppService.PersistirCelula(celula);
//                return Ok(celula);
//            }
//            catch (Exception e)
//            {
//                return InternalServerError(e);
//            }
//        }

//        [HttpPost]
//        [Route("Celula/EditarCelula/")]
//        [ResponseType(typeof(CelulaViewModel))]
//        public async Task<IHttpActionResult> PostEditarCelula(CelulaViewModel celula)
//        {
//            if (celula == null)
//                return BadRequest();
//            try
//            {
//                //await _celulaAppService.EditarCelula(celula);
//                return Ok(celula);
//            }
//            catch (Exception e)
//            {
//                return InternalServerError(e);
//            }
//        }

//        [HttpGet]
//        [Route("Celula/ObterTodos")]
//        [ResponseType(typeof(IEnumerable<DropDownItemViewModel>))]
//        public async Task<IHttpActionResult> GetObterTodos()
//        {
//            try
//            {
//                return Ok(await _celulaAppService.PreencherComboCelula());
//            }
//            catch (Exception e)
//            {
//                return InternalServerError(e);
//            }
//        }

//        [HttpGet]
//        [Route("Celula/ObterCelula/{id}")]
//        [ResponseType(typeof(CelulaViewModel))]
//        public async Task<IHttpActionResult> GetObterCelula(int id)
//        {
//            try
//            {
//                return Ok(await _celulaAppService.ObterCelula(id));
//            }
//            catch (Exception e)
//            {
//                return InternalServerError(e);
//            }
//        }

//        [HttpGet]
//        [Route("Celula/ObterCelulasPorUnidade/{id}")]
//        [ResponseType(typeof(IEnumerable<DropDownItemViewModel>))]
//        public async Task<IHttpActionResult> GetObterCelulasPorUnidade(int id)
//        {
//            if (id == null)
//                return BadRequest();
//            try
//            {
//                return Ok(await _celulaAppService.ObterCelulaUnidade(id));

//            }
//            catch (Exception e)
//            {
//                return InternalServerError(e);
//            }
//        }

//        [HttpGet]
//        [Route("Celula/RemoverCelula/{id}")]
//        public async Task<IHttpActionResult> GetRemoverCelula(int id)
//        {
//            if (id == 0)
//                return BadRequest();
//            try
//            {
//                await _celulaAppService.RemoverCelula(id);
//                return Ok(id);

//            }
//            catch (Exception e)
//            {
//                return InternalServerError(e);
//            }
//        }

//        [HttpGet]
//        [Route("Celula/VerficaExistenciaColaboradores/{id}")]
//        public async Task<IHttpActionResult> GetExisteColabrador(int id)
//        {
//            if (id == 0)
//                return BadRequest();
//            try
//            {
//                await _celulaAppService.VerificaExistenciaColaboradores(id);
//                return Ok(id);

//            }
//            catch (Exception e)
//            {
//                return InternalServerError(e);
//            }
//        }

//        [HttpGet]
//        [Route("Celula/VerificaExistenciaRelacao/{id}")]
//        [ResponseType(typeof(bool))]
//        public async Task<IHttpActionResult> GetExistenciaRelacoes(int id)
//        {
//            try
//            {
//                return Ok(await _celulaAppService.VerificaExistenciaColaboradores(id));

//            }
//            catch (Exception e)
//            {
//                return InternalServerError(e);
//            }
//        }

//        [HttpGet]
//        [Route("Celula/VerificaExistenciaGestor/{celulaId}/{unidadeId}")]
//        [ResponseType(typeof(bool))]
//        public async Task<IHttpActionResult> GetExistenciaGestor(int celulaId, int unidadeId)
//        {
//            try
//            {
//                return Ok(await _celulaAppService.VerficaExistenciaGestor(celulaId, unidadeId));

//            }
//            catch (Exception e)
//            {
//                return InternalServerError(e);
//            }
//        }

//        [HttpGet]
//        [Route("Celula/ObterCelulasSupervisionadasPorColaborador/{login}")]
//        [ResponseType(typeof(bool))]
//        public async Task<IHttpActionResult> GetObterCelulasSupervisionadasPorColaborador(string login)
//        {
//            try
//            {
//                return Ok(await _celulaAppService.ObterCelulasSupervisionadas(login));

//            }
//            catch (Exception e)
//            {
//                return InternalServerError(e);
//            }
//        }
//    }


//}
