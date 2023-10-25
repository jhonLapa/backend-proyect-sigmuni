using Jca.Sigmuni.Application.Dtos.General.Uits;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class UitController : ControllerBase
    {
        private readonly ILogger<UitController> _logger;
        private readonly IUitService _uitService;

        public UitController(ILogger<UitController> logger, IUitService uitService)
        {
            _logger = logger;
            _uitService = uitService;
        }

        [AllowAnonymous]

        [HttpGet("ObtenerMontoUit/{anio}")]
        public async Task<UitDto> ObtenerMontoUitAsync(int anio)
        {
            var operacion = await _uitService.ObtenerMontoUitxAnio(anio);
            return operacion;
        }


    }
}
