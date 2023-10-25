using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoComplementarioController : ControllerBase
    {
        private readonly ILogger<InfoComplementarioController> _logger;
        private readonly IInfoComplementarioService _infoComplementarioService;

        public InfoComplementarioController(ILogger<InfoComplementarioController> logger, IInfoComplementarioService infoComplementarioService)
        {
            _logger = logger;
            _infoComplementarioService = infoComplementarioService;
        }


        [HttpGet]
        public async Task<IEnumerable<InfoComplementarioDto>> Get()
        => await _infoComplementarioService.FindAll();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfoComplementarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<InfoComplementarioDto>>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfoComplementarioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<InfoComplementarioDto>>> Post([FromBody] InfoComplementario request)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfoComplementarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<InfoComplementarioDto>>> Delete(int id)
        {
            throw new NotImplementedException();
        }


        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<InfoComplementarioDto>> PaginatedSearch([FromQuery] RequestPagination<InfoComplementarioDto> request)
        {
            throw new NotImplementedException();
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfoComplementarioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<bool>>> EditPersona(int id, [FromBody] InfoComplementarioDto request)
        {
            throw new NotImplementedException();
        }
    }
}
