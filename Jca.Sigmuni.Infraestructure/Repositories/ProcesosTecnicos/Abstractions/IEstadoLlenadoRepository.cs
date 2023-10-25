using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IEstadoLlenadoRepository
    {
        Task<IList<EstadoLlenado>> FindAll();
    }
}
