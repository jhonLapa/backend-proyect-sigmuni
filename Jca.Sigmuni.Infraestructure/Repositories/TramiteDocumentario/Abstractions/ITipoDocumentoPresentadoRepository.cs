using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface ITipoDocumentoPresentadoRepository
    {
        Task<IList<TipoDocumentoPresentado>> FindAll();

    }
}
