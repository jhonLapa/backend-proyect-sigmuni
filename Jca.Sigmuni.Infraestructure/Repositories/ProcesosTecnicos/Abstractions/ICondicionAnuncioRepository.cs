using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ICondicionAnuncioRepository
    {
        Task<IList<CondicionAnuncio>> FindAll();
    }
}
