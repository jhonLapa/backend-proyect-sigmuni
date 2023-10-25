using Jca.Sigmuni.Application.Dtos.Admins.AreaCargos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.CategoriaRangos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class ProcedimientoController :ControllerBase
    {
        private readonly ILogger<ProcedimientoController> _logger;
        private readonly IProcedimientoService _procedimientoService;
        private readonly IActividadService _actividadService;
        private readonly IProcedimientoNormaInteresRepository _procedimientoNormaInteresRepository;
        private readonly IProcedimientoNormaInteresService _procedimientoNormaInteresService;

        public ProcedimientoController(ILogger<ProcedimientoController> logger, IProcedimientoService procedimientoService, IActividadService actividadService, IProcedimientoNormaInteresRepository procedimientoNormaInteresRepository,IProcedimientoNormaInteresService procedimientoNormaInteresService)
        {
            _logger = logger;
            _procedimientoService = procedimientoService;
            _actividadService = actividadService;
            _procedimientoNormaInteresRepository = procedimientoNormaInteresRepository;
            _procedimientoNormaInteresService = procedimientoNormaInteresService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProcedimientoDto>> Get()
        => await _procedimientoService.FindAll();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProcedimientoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ProcedimientoDto>>> Get(int id)
        {
            var response = await _procedimientoService.Find(id);
            if (response == null) return TypedResults.NotFound();
            return TypedResults.Ok(response);
        }


        [HttpGet("FindTramite/{idTipoTramite}")]
        public async Task<IEnumerable<ProcedimientoDto>> FindTramite(int idTipoTramite)
       => await _procedimientoService.FindTramite(idTipoTramite);


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProcedimientoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<ProcedimientoDto>>> Post([FromBody] ProcedimientoDto request)
        {
            var response = await _procedimientoService.CreateProcedimiento(request);

            #region "Registrar norma interes"
            if (request.ProcedimientoNormaInteres != null && request.ProcedimientoNormaInteres.Count > 0)
            {
                await _procedimientoNormaInteresService.CreateMultipleNormaInteres(request.ProcedimientoNormaInteres, response.Id);
            }
            #endregion

            #region "Registrar actividad"
            if (request.Actividad != null && request.Actividad.Count > 0)
            {
                await _actividadService.Createmultiple(request.Actividad, response.Id);
            }
            #endregion

            if (response == null) return TypedResults.BadRequest();
            return TypedResults.Ok(response);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProcedimientoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ProcedimientoDto>>> Delete(int id)
        { 
            var response=await _procedimientoService.Disable(id);
            if(response == null) return TypedResults.NotFound();
            return TypedResults.Ok(response);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<ProcedimientoDto>> PaginatedSearch([FromQuery] RequestPagination<ProcedimientoDto> request)
            => await _procedimientoService.PaginatedSearch(request);

        [HttpGet("obtenerUltimo")]
        public async  Task<ProcedimientoDto>ObtenerUltimo()
            => await _procedimientoService.ObtenerUltimoSolicitud();

 
    }
}
