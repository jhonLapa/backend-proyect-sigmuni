using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoInformes;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoInformeController : ControllerBase
    {
        private readonly ITipoInformeService _TipoInformeService;

        public TipoInformeController(ITipoInformeService TipoInformeService)
        {
            _TipoInformeService = TipoInformeService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoInformeDto>> Get()
       => await _TipoInformeService.FindAll();


    }
}
