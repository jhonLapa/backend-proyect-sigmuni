using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Naturalezas;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class NaturalezaController:Controller
    {
        private readonly INaturalezaService _naturalezaService;

        public NaturalezaController(INaturalezaService naturaService) { 
            _naturalezaService= naturaService;
        }

        [HttpGet]
        public async Task<IEnumerable<NaturalezaDto>>Get()
            =>await _naturalezaService.findAll();   

    }
}
