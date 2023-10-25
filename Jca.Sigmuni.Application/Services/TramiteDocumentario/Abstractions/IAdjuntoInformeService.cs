using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeDocumentos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IAdjuntoInformeService
    {
        Task<bool> AdjuntarDocumentoAsync(InformeDocumento peticion);
        Task<bool> AdjuntarDocumentoDescripcionAsync(InformeDocumento peticion);
        Task<InformeDocumentoDto?> BuscarInformeDocumento(int idInforme, int flag);
        Task<InformeDocumentoDto?> BuscarInformeDocumentoDescripcion(int idInforme, int flag, string descripcion);

        Task<bool> Disable(InformeDocumentoDto peticion);
    }
}
