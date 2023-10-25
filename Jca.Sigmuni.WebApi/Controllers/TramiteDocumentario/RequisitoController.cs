using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Requisitos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitoController : ControllerBase
    {
        private readonly IRequisitoService _RequisitoService;

        public RequisitoController(IRequisitoService RequisitoService)
        {
            _RequisitoService = RequisitoService;
        }


        [HttpGet]
        public async Task<IEnumerable<RequisitoDto>> Get()
       => await _RequisitoService.FindAll();


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequisitoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<RequisitoDto>>> Post([FromBody] RequisitoFormDto request)
        {
            var response = await _RequisitoService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequisitoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<RequisitoDto>>> EditRequisito(int id, [FromBody] RequisitoFormDto request)
        {
            var response = await _RequisitoService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequisitoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<RequisitoDto>>> Delete(int id)
        {
            var response = await _RequisitoService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequisitoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<RequisitoDto>>> Get(int id)
        {
            var response = await _RequisitoService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [AllowAnonymous]

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<RequisitoDto>> PaginatedSearch([FromQuery] RequestPagination<RequisitoDto> request)
       => await _RequisitoService.PaginatedSearch(request);
    }
}
