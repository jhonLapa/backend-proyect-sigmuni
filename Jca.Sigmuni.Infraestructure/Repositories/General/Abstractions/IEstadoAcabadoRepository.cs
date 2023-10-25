using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IEstadoAcabadoRepository
    {
        Task<IList<EstadoAcabado>> FindAll();
    }
}
