using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface IProcedimientoRequisitoRepository : IRepositoryCrud<ProcedimientoRequisito, int>, IRepositoryPaginated<ProcedimientoRequisito>
    {
        Task<List<ProcedimientoRequisito>> ListarxProcedimientoAsync(int idProcedimiento);
        Task<ProcedimientoRequisito> BuscarProcedimientoRequisitoPorIdProcedimientoIdRequisitoAsync(int idProcedimiento, int idRequisito);
    }
}
