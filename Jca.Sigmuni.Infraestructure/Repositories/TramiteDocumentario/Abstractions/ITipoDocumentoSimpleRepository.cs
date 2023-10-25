using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface ITipoDocumentoSimpleRepository
    {
        Task<IList<TipoDocumentoSimple>> FindAll();
    }
}
