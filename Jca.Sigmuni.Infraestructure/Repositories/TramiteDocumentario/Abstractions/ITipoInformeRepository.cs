using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface ITipoInformeRepository
    {
        Task<IList<TipoInforme>> FindAll();

    }
}
