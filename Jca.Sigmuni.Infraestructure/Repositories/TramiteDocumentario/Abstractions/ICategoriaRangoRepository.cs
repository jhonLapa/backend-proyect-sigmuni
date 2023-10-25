using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface ICategoriaRangoRepository : IRepositoryCrud<CategoriaRango, int>, IRepositoryPaginated<CategoriaRango>
    {
        Task<List<CategoriaRango>> ObtenerCategoriaRangoxProcedimiento(int id, int anio);
    }
}
