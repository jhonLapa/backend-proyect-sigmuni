using Jca.Sigmuni.Application.Dtos.General.FiliacionesCronologicas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class FiliacionCronologicaController : ControllerBase
    {
        private readonly IFiliacionCronologicaService _filiacionCronologicaService;

        public FiliacionCronologicaController(IFiliacionCronologicaService filiacionCronologicaService)
        {
            _filiacionCronologicaService = filiacionCronologicaService;
        }


        [HttpGet]
        public async Task<IEnumerable<FiliacionCronologicaDto>> Get()
       => await _filiacionCronologicaService.FindAll();

    }
}
