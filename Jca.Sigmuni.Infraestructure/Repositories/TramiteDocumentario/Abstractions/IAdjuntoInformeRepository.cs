using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface IAdjuntoInformeRepository
    {
        Task<AdjuntoInforme> BuscarInformeDocumento(int idInforme, int flag);

        Task<AdjuntoInforme> BuscarInformeDocumentoDescripcion(int idInforme, int flag, string descripcion);
        Task<AdjuntoInforme> BuscarInformeDocumentoDescripcionFalse(int idInforme, int flag, string descripcion);

        Task<AdjuntoInforme> BuscarPorIdYNoBorradoAsync(int id);
        Task<AdjuntoInforme> BuscarPorIdAsync(int id);
        Task<AdjuntoInforme> Create(AdjuntoInforme entity);
        Task<AdjuntoInforme?> Edit(int id, AdjuntoInforme entity);
        Task<AdjuntoInforme?> Disable(int id);
    }
}
