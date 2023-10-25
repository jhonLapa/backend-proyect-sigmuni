using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IObservacionRepository
    {
        Task<IList<Observacion>> FindAll();
    }
}
