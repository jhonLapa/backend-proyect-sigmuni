using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface IMonedaRepository
    {
        Task<IList<Moneda>> FindAll();

    }
}
