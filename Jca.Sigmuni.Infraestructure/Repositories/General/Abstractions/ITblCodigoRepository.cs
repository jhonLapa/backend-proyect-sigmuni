using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface ITblCodigoRepository : IRepositoryCrud<TblCodigo, int>, IRepositoryPaginated<TblCodigo>
    {
        Task<TblCodigo?> BuscarPorIdUnidadCatastralAsync(int id);
    }
}
