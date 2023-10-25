using Jca.Sigmuni.Application.Dtos.General.AfectacionesNaturales;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class AfectacionNaturalController : ControllerBase
    {
        private readonly IAfectacionNaturalService _afectacionNaturalService;

        public AfectacionNaturalController(IAfectacionNaturalService afectacionNaturalService)
        {
            _afectacionNaturalService = afectacionNaturalService;
        }


        [HttpGet]
        public async Task<IEnumerable<AfectacionNaturalDto>> Get()
       => await _afectacionNaturalService.FindAll();

    }
}
