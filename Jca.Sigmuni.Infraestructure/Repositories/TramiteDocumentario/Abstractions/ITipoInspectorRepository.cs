using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface ITipoInspectorRepository
    {
        Task<IList<TipoInspector>> FindAll();

    }
}
