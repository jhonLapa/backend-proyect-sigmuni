using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ucas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class UcaController : ControllerBase
    {
        private readonly IUcaService _ucaService;

        public UcaController(IUcaService ucaService)
        {
            _ucaService = ucaService;
        }


        [HttpGet]
        public async Task<IEnumerable<UcaDto>> Get()
       => await _ucaService.FindAll();


    }
}
