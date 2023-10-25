using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IFichaBienCulturalRepository :IRepositoryCrud<FichaBienCultural, int>
    {
        
        Task<FichaBienCultural> BuscarPorIdAsync(int id);
    }
}
