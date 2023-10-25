using Jca.Sigmuni.Application.Dtos.General.FiliacionesEstilisticas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class FiliacionEstilisticaController : ControllerBase
    {
        private readonly IFiliacionEstilisticaService _filiacionEstilisticaService;

        public FiliacionEstilisticaController(IFiliacionEstilisticaService filiacionEstilisticaService)
        {
            _filiacionEstilisticaService = filiacionEstilisticaService;
        }


        [HttpGet]
        public async Task<IEnumerable<FiliacionEstilisticaDto>> Get()
       => await _filiacionEstilisticaService.FindAll();

    }
}
