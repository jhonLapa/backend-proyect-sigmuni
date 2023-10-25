using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Inplementations
{
    public class InfDocumentoService : IInfDocumentoService
    {
        private readonly IMapper _mapper;
        private readonly IInfDocumentoRepository _infDocumentoRepository;

        public InfDocumentoService(IMapper mapper, IInfDocumentoRepository infDocumentoRepository)
        {
            _mapper = mapper;
            _infDocumentoRepository = infDocumentoRepository;
        }

        public async Task<InfDocumentoDto> Create(InfDocumentoFormDto dto)
        {
            var validacion = await _infDocumentoRepository.BuscarXsolicitud(dto.IdSolicitud);


            if (validacion != null)
            {
                throw new Exception("numero de solicitudya con informe");
                return _mapper.Map<InfDocumentoDto>(validacion);

            };

            var infDocumento = new InfDocumento();
            infDocumento.NumRegistro = dto.NumRegistro;
            infDocumento.RazonSocial = dto.RazonSocial;
            infDocumento.Asunto = dto.Asunto;
            infDocumento.InformacionRelevante = dto.InformacionRelevante;
            infDocumento.FechaInicio = dto.FechaInicio;
            infDocumento.FechaTermino = dto.FechaTermino;
            infDocumento.NumFolios = dto.NumFolios;
            infDocumento.TotalImagenes = dto.TotalImagenes;
            infDocumento.Mayora3 = dto.Mayora3;
            infDocumento.TapaContratapa = dto.TapaContratapa;
            infDocumento.NumUnidadCaja = dto.NumUnidadCaja;
            infDocumento.Anio = dto.Anio;
            infDocumento.Observaciones = dto.Observaciones;
            infDocumento.NumModulo = dto.NumModulo;
            infDocumento.Lado = dto.Lado;
            infDocumento.NumCuerpo = dto.NumCuerpo;
            infDocumento.NumBalda = dto.NumBalda;
            infDocumento.IdSolicitud = dto.IdSolicitud;
            infDocumento.IdSeccionDocumento = dto.IdSeccionDocumento;
            infDocumento.IdTipoDocumental = dto.IdTipoDocumental;
            infDocumento.IdSerieDocumental = dto.IdSerieDocumental;
            infDocumento.IdSubSerieDoc = dto.IdSubSerieDoc;
            infDocumento.NumCaja = dto.NumCaja;
            infDocumento.NumConcatRegistro = dto.NumConcatRegistro;



            var entity = infDocumento;
            var response = await _infDocumentoRepository.Create(entity);

            return _mapper.Map<InfDocumentoDto>(response);
        }

        public async Task<InfDocumentoDto?> Disable(int id)
        {
            var response = await _infDocumentoRepository.Disable(id);
            return _mapper.Map<InfDocumentoDto>(response);
        }

        public async Task<InfDocumentoDto?> Edit(int id, InfDocumentoFormDto dto)
        {
            var infDocumento = new InfDocumento();
            infDocumento.NumRegistro = dto.NumRegistro;
            infDocumento.RazonSocial = dto.RazonSocial;
            infDocumento.Asunto = dto.Asunto;
            infDocumento.InformacionRelevante = dto.InformacionRelevante;
            infDocumento.FechaInicio = dto.FechaInicio;
            infDocumento.FechaTermino = dto.FechaTermino;
            infDocumento.NumFolios = dto.NumFolios;
            infDocumento.TotalImagenes = dto.TotalImagenes;
            infDocumento.Mayora3 = dto.Mayora3;
            infDocumento.TapaContratapa = dto.TapaContratapa;
            infDocumento.NumUnidadCaja = dto.NumUnidadCaja;
            infDocumento.Anio = dto.Anio;
            infDocumento.Observaciones = dto.Observaciones;
            infDocumento.NumModulo = dto.NumModulo;
            infDocumento.Lado = dto.Lado;
            infDocumento.NumCuerpo = dto.NumCuerpo;
            infDocumento.NumBalda = dto.NumBalda;
            infDocumento.IdSolicitud = dto.IdSolicitud;
            infDocumento.IdSeccionDocumento = dto.IdSeccionDocumento;
            infDocumento.IdTipoDocumental = dto.IdTipoDocumental;
            infDocumento.IdSerieDocumental = dto.IdSerieDocumental;
            infDocumento.IdSubSerieDoc = dto.IdSubSerieDoc;
            infDocumento.NumCaja = dto.NumCaja;
            infDocumento.NumConcatRegistro = dto.NumConcatRegistro;



            var entity = infDocumento;
            var response = await _infDocumentoRepository.Edit(id, entity);

            return _mapper.Map<InfDocumentoDto>(response);
        }

        public async Task<InfDocumentoDto?> Find(int id)
        {
            var response = await _infDocumentoRepository.Find(id);

            return _mapper.Map<InfDocumentoDto>(response);
        }

        public async Task<IList<InfDocumentoDto>> FindAll()
        {
            var response = await _infDocumentoRepository.FindAll();
            return _mapper.Map<IList<InfDocumentoDto>>(response);
        }

        public async Task<InfDocumentoDto> ObtenerUltimoNumeroInf()
        {
            var response = await _infDocumentoRepository.ObtenerUltimoNumeroInf();
            return _mapper.Map<InfDocumentoDto>(response);
        }


        public async Task<ResponsePagination<InfDocumentoDto>> PaginatedSearch(RequestPagination<InfDocumentoDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<InfDocumento>>(dto);
            var response = await _infDocumentoRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<InfDocumentoDto>>(response);
        }
    }
}
