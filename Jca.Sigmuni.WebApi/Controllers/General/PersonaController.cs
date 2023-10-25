using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly ILogger<PersonaController> _logger;
        private readonly IPersonaService _personaService;
        private readonly IDomicilioService _domicilioService;
        private readonly IInfoContactoService _infoContactoService;
        private readonly IExoneracionTitularService _exoneracionTitularService;

        public PersonaController(ILogger<PersonaController> logger, IPersonaService personaService,IDomicilioService domicilioService, IInfoContactoService infoContactoService, IExoneracionTitularService exoneracionTitularService)
        {
            _domicilioService = domicilioService;
            _logger = logger;
            _personaService = personaService;
            _infoContactoService = infoContactoService;
            _exoneracionTitularService = exoneracionTitularService;
        }


        [HttpGet]
        public async Task<IEnumerable<PersonaDto>> Get()
        => await _personaService.FindAll();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<PersonaDto>>> Get(int id)
        {
            var response = await _personaService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost("CrearPersona")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<PersonaDto>>> Post([FromBody] PersonaFormDto request)
        {
            
            var response = await _personaService.CrearPersona(request);

            if (request.InfoContacto != null)
            {
                await _infoContactoService.CrearInfoContacto(request.InfoContacto, response.Id, response.IdTipoPersona);
            }


            if (request.Domicilio != null)
            {
                await _domicilioService.CrearDomicilo(request.Domicilio, response.Id);
            }

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<PersonaDto>>> Delete(int id)
        {
            var response = await _personaService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<PersonaDto>> PaginatedSearch([FromQuery] RequestPagination<PersonaDto> request)
        => await _personaService.PaginatedSearch(request);


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<bool>>> EditPersona(int id, [FromBody] PersonaFormDto request)
        {
            var response = await _personaService.EditPersona(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("BusquedaPorNumeroDoc/{numeroDoc}")]
        public async Task<bool>BusquedaPorNumeroDoc(string numeroDoc)
        {
            var response= await _personaService.BusquedaPersonaPorNumDoc(numeroDoc);
            return response;
        }

        [HttpGet("BusquedaPorNumeroRuc/{numeroRuc}")]
        public async Task<bool> BusquedaPorNumeroRuc(string numeroRuc)
        {
            var response = await _personaService.BusquedaPersonaPorNumRuc(numeroRuc);
            return response;
        }
    }
}
