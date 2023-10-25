using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IAutorizacionMunicipalRepository : IRepositoryCrud<AutorizacionMunicipal, int>
    {
        Task<AutorizacionMunicipal> BuscarPorIdAsync(int id);
        Task<bool> EliminarAsync(int id);
        Task<List<AutorizacionMunicipal>> ListarPorIdFichaAsync(int idFicha);
    }
}
