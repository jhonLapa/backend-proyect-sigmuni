using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TIpoNormas;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class TipoNormaController : Controller
    {
        private readonly ITipoNormaService _tipoNormaService;
        public TipoNormaController(ITipoNormaService tipoNormaService)
        {
            _tipoNormaService = tipoNormaService;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoNormaDto>>Get()
            => await _tipoNormaService.findAll();

    }
}
