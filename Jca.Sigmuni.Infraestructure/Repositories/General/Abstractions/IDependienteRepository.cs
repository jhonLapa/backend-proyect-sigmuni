using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IDependienteRepository : IRepositoryCrud<Dependiente, int>
    {
        Task<List<Dependiente>> ListarPorIdLitiganteAsync(int idLitigante);
        Task<bool> EliminarAsync(int id);
        Task<List<Dependiente>> ListarPorIdTitularCatastralAsync(int idTitularCatastral);
    }
}
