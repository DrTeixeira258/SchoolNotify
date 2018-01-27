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
    }
}