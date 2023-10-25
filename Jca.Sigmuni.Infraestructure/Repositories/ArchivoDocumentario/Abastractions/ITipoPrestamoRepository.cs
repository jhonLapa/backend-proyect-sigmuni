using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions
{
    public interface  ITipoPrestamoRepository : IRepositoryCrud<TipoPrestamo, int>, IRepositoryPaginated<TipoPrestamo>
    {
    }
}
