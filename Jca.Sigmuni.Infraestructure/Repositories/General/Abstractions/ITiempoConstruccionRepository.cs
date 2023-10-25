using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface ITiempoConstruccionRepository
    {
        Task<IList<TiempoConstruccion>> FindAll();
    }
}
