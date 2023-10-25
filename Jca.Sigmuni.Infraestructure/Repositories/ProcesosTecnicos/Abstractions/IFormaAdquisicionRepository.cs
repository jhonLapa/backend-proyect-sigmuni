using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IFormaAdquisicionRepository
    {
        Task<IList<FormaAdquisicion>> FindAll();
    }
}
