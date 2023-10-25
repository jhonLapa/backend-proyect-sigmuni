using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoAnuncioRepository
    {
        Task<IList<TipoAnuncio>> FindAll();
    }
}
