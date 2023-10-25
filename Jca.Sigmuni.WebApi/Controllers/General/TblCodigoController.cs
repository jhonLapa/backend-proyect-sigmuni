using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblCodigoController : ControllerBase
    {
        private readonly ILogger<TblCodigoController> _logger;
        private readonly ITblCodigoService _tblCodigoService;

        public TblCodigoController(ILogger<TblCodigoController> logger, ITblCodigoService tblCodigoService)
        {
            _logger = logger;
            _tblCodigoService = tblCodigoService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TblCodigoCatastralDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<TblCodigoCatastralDto>>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TblCodigoCatastralDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<TblCodigoCatastralDto>>> Post([FromBody] TblCodigo request)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TblCodigoCatastralDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<TblCodigoCatastralDto>>> Delete(int id)
        {
            throw new NotImplementedException();
        }


        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<TblCodigoCatastralDto>> PaginatedSearch([FromQuery] RequestPagination<TblCodigoCatastralDto> request)
        {
            throw new NotImplementedException();
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TblCodigoCatastralDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<bool>>> EditPersona(int id, [FromBody] TblCodigoCatastralDto request)
        {
            throw new NotImplementedException();
        }

        [HttpGet("TblCodigoPorIdFicha/{idFicha}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TblCodigoCatastralDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<TblCodigoCatastralDto>>> TblCodigoPorIdFicha(int idFicha)
        {
            var response = await _tblCodigoService.BuscarPorIdFichaAsync(idFicha);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
    }
}
