using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UsosPredios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class UsoPredioController : ControllerBase
    {
        private readonly IUsoPredioService _usoPredioService;

        public UsoPredioController(IUsoPredioService usoPredioService)
        {
            _usoPredioService = usoPredioService;
        }


        [HttpGet]
        public async Task<IEnumerable<UsoPredioDto>> Get()
       => await _usoPredioService.FindAll();


    }
}
