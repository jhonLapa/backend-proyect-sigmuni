using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDocumentoPresentados;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoPresentadoController : ControllerBase
    {
        private readonly ITipoDocumentoPresentadoService _TipoDocumentoPresentadoService;

        public TipoDocumentoPresentadoController(ITipoDocumentoPresentadoService TipoDocumentoPresentadoService)
        {
            _TipoDocumentoPresentadoService = TipoDocumentoPresentadoService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoDocumentoPresentadoDto>> Get()
       => await _TipoDocumentoPresentadoService.FindAll();


    }
}
