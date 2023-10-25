using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TramiteDocumentos;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions
{
    public interface ITramiteDocumentoService : IServiceCrud<TramiteDocumentoDto, TramiteDocumentoFormDto, int>, IServicePaginated<TramiteDocumentoDto>
    {
        Task<TramiteDocumentoDto> CrearOActualizarActualizadoAsync(List<TramiteDocumentoPFormDto> peticion);

        Task<TramiteDocumentoObtenerDto> ObtenerPorIdAsync(int id);
        Task<TramiteDocumentoDto> ObtenerUltimoNumeroTramiteDo();
    }
}
