using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PrediosCatastralesEn;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class PredioCatastralEnController : ControllerBase
    {
        private readonly IPredioCatastralEnService _predioCatastralEnService;

        public PredioCatastralEnController(IPredioCatastralEnService predioCatastralEnService)
        {
            _predioCatastralEnService = predioCatastralEnService;
        }


        [HttpGet]
        public async Task<IEnumerable<PredioCatastralEnDto>> Get()
       => await _predioCatastralEnService.FindAll();


    }
}
