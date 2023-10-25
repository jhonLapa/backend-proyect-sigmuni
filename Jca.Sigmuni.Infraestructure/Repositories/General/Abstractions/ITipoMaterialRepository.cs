using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface ITipoMaterialRepository
    {
        Task<IList<TipoMaterial>> FindAll();
    }
}
