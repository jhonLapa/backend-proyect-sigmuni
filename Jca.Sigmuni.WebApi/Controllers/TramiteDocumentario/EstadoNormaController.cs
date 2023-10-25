using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.EstadoNormas;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class EstadoNormaController:Controller
    {
        private readonly IEstadoNormaService _estadoNormaService;

        public EstadoNormaController(IEstadoNormaService estadoNormaService)
        {
            _estadoNormaService = estadoNormaService;
        }

        [HttpGet]
        public async Task<IEnumerable<EstadoNormaDto>>Get()
            =>await _estadoNormaService.findAll();  
    }
}
