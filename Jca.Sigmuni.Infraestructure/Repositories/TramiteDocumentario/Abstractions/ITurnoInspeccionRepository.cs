using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface ITurnoInspeccionRepository
    {
        Task<IList<TurnoInspeccion>> FindAll();

    }
}
