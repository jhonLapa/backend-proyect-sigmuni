using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudRequisitos;
using Jca.Sigmuni.Application.Services.Vias.LoteZonificacionParametros;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IInformeTecnicoService : IServicePaginated<InformeTecnicoPaginadoDto>
    {
        Task<DatosSolicitudDto> ObtenerSolicitudAsync(string numSolicitud);
        Task<InformeTecnicoRespuestaDto> CrearAsync(InformeTecnicoDto peticion);
        Task<string> BuscarMaxRegistroCorrelativoAsyn();
        Task<List<SolicitudRequisitoDto>> ListarxSolicitudAsync(int idSolicitud);
        Task<LoteZonificacionParametroDto> ObtenerPorIdLoteCartografiaAsync(string IdLoteCartografia);
        Task<InformeTecnicoDto> ObtenerinformeId(int idInforme);
        Task<InformeTecnicoDto> ObtenerInformePorIdSolicitud(int idSolicitud);
        Task<InformeTecnicoDto?> EstadoGeneradoInforme(int id);

        Task<DatosSolicitudDto> ObtenerAsyncSolicitudxAnioxNumero(string numSolicitud, int anio);
    }
}
