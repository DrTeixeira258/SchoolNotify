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
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioApplicationService _usuarioAppService;

        public UsuarioController(IUsuarioApplicationService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        [Route("Usuario/Logar")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Logar(UsuarioViewModel usuario)
        {
            try
            {
                return Ok(await _usuarioAppService.Logar(usuario));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("Usuario/Cadastrar")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Cadastrar(UsuarioViewModel usuario)
        {
            try
            {
                return Ok(await _usuarioAppService.Cadastrar(usuario));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}