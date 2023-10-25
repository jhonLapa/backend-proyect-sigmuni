using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions
{
    public interface IInfDocumentoSPRepository : IRepositoryCrud<InfDocumento, int>, IRepositoryPaginated<InfDocumento>
    {
        Task<InfDocumento?> ListarDetalleAsync(string numExpendiente, string anioExpediente);
    }
}
