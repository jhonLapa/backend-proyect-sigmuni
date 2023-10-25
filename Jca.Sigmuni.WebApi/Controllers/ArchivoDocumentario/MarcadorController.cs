using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Expedientes;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Marcadores;
using Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ArchivoDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcadorController : ControllerBase
    {
        private readonly ILogger<MarcadorController> _logger;
        private readonly IMarcadorService _marcadorService;
        private readonly IDocumentoService _documentoService;
        private readonly IExpedienteService _expedienteService;

        public MarcadorController(ILogger<MarcadorController> logger, IMarcadorService marcadorService, IDocumentoService documentoService, IExpedienteService expedienteService)
        {
            _logger = logger;
            _marcadorService = marcadorService;
            _documentoService = documentoService;
            _expedienteService = expedienteService;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<MarcadorDto>> Get()
        => await _marcadorService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarcadorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<MarcadorDto>>> Get(int id)
        {
            var response = await _marcadorService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarcadorDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<MarcadorDto>>> Post([FromBody] MarcadorFormDto request)
        {
            var response = await _marcadorService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }
        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarcadorDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<MarcadorDto>>> Put(int id, [FromBody] MarcadorFormDto request)
        {
            var response = await _marcadorService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<MarcadorDto>> PaginatedSearch([FromQuery] RequestPagination<MarcadorDto> request)
        => await _marcadorService.PaginatedSearch(request);

        [HttpPost("CrearExpedienteXMarcador")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarcadorDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<MarcadorDto>>> PostMarcadorExpediente([FromBody] MarcadorExpedienteDto request)
        {


            //if (request.Documento != null &&  request.Documento.Contenido == "System.Byte[]")
            //{
            //    //var responseDocumento = await _documentoService.Create(request.Documento);
            //    request.Expediente.IdDocumento = request.Expediente.IdDocumento;
            //}


            if (request.Documento != null )
            {
                var responseDocumento = await _documentoService.Create(request.Documento);
                request.Expediente.IdDocumento = responseDocumento.IdDocumentoB64;
            }

            var expediente = new ExpedienteFormDto();
            var responseExpediente = new ExpedienteDto();

            if (request.Expediente.Id != 0)
            {
                expediente.Id = request.Expediente.Id;
                expediente.IdDocumento = request.Expediente.IdDocumento;
                expediente.IdInfDocumento = request.Expediente.IdInfDocumento;
                expediente.Folios = request.Expediente.Folios;
                expediente.Estado = true;


                responseExpediente = await _expedienteService.Edit(expediente.Id, expediente);

            }
            else
            {
                expediente.IdDocumento = request.Expediente.IdDocumento;
                expediente.IdInfDocumento = request.Expediente.IdInfDocumento;
                expediente.Folios = request.Expediente.Folios;
                expediente.Estado = true;


                responseExpediente = await _expedienteService.Create(expediente);
            }

            var responseMarcadores = new MarcadorDto();
            var marcadores = new MarcadorFormDto();

            //if (responseExpediente != null)
            //{
            //    if(request.Marcadores.Count != 0)
            //    {
            //        for (int i = 0; i < request.Marcadores.Count; i++)
            //        {
            //            var find = await _marcadorService.Find(request.Marcadores[i].Id);
            //            if (find != null)
            //            {
            //                responseMarcadores = find;
            //            }
            //            else
            //            {
            //                marcadores.Pagina = request.Marcadores[i].Pagina;
            //                marcadores.Descripcion = request.Marcadores[i].Descripcion;
            //                marcadores.IdExpediente = responseExpediente.Id;

            //                responseMarcadores = await _marcadorService.Create(marcadores);
            //            }
            //        }
            //    }
            //}


            if (responseExpediente != null)
            {
                if (request.Marcador != null)
                {

                    var find = await _marcadorService.Find(request.Marcador.Id);
                    if (find != null)
                    {
                        responseMarcadores = find;
                    }
                    else
                    {
                        marcadores.Pagina = request.Marcador.Pagina;
                        marcadores.Descripcion = request.Marcador.Descripcion;
                        marcadores.IdExpediente = responseExpediente.Id;

                        responseMarcadores = await _marcadorService.Create(marcadores);
                    }

                }
            }


            if (responseMarcadores == null) return TypedResults.BadRequest();

            return TypedResults.Ok(responseMarcadores);
        }
    }
}
