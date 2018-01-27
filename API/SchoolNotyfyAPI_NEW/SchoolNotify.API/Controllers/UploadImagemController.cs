using SchoolNotify.Application.Interfaces;
using SchoolNotify.Application.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SchoolNotify.API.Controllers
{
    [RoutePrefix("api")]
    public class UploadImagemController : ApiController
    {
        private readonly IUploadImagemApplicationService _uploadImagemApplicationService;
        public UploadImagemController(IUploadImagemApplicationService uploadImagemApplicationService)
        {
            _uploadImagemApplicationService = uploadImagemApplicationService;
        }

        [HttpPost]
        [Route("UploadImagem/SalvarImagem")]
        [ResponseType(typeof(UploadImagemViewModel))]
        public async Task<IHttpActionResult> PostSalvarImagem(UploadImagemViewModel imagem)
        {
            try
            {
                await _uploadImagemApplicationService.UploadImagem(imagem);
                return Ok(imagem);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}