using Jca.Sigmuni.Application.Dtos.CompendioNormas.ClasificacionNormas;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class ClasificacionNormaController:Controller
    {
        private readonly IClasificacionNormaService _clasificacionNormaService;

        public ClasificacionNormaController(IClasificacionNormaService clasificacionNormaService)
        {
            _clasificacionNormaService = clasificacionNormaService;
        }

        [HttpGet]
        public async Task<IEnumerable<ClasificacionNormaDto>>Get()
            =>await _clasificacionNormaService.findAll();
    }
}
