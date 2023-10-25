using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abastractions
{
    public interface IControlFichaRepository : IRepositoryCrud<ControlFicha, int>, IRepositoryPaginated<ControlFicha>
    {
        Task<ControlFicha?> BuscarPorControlFicha(ControlFicha controlFicha);
        Task<List<ControlFicha>> BuscarPorIdUnidadCatastralAsync(int idUnidadCatastral);
        Task<List<ControlFicha>> BuscarPorIdFichaAsync(int idFicha);
    }
}
