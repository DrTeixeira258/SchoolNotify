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
    public class TokenController : ApiController
    {
        private readonly ITokenApplicationService _tokenAppService;

        public TokenController(ITokenApplicationService tokenAppService)
        {
            _tokenAppService = tokenAppService;
        }

        [HttpPost]
        [Route("Token/BuscarTokensPorTelefones")]
        [ResponseType(typeof(IEnumerable<string>))]
        public async Task<IHttpActionResult> BuscarTokensPorTelefones(IEnumerable<long> telefones)
        {
            try
            {
                return Ok(await _tokenAppService.BuscarTokensPorTelefones(telefones));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("Token/SalvarToken")]
        [ResponseType(typeof(IEnumerable<string>))]
        public async Task<IHttpActionResult> SalvarToken(TokenViewModel token)
        {
            try
            {
                return Ok(await _tokenAppService.SalvarToken(token));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}