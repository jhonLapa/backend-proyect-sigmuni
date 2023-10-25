using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions
{
    public interface ITipoDocumentalRepository : IRepositoryCrud<TipoDocumental, int>, IRepositoryPaginated<TipoDocumental>
    {
    }
}
