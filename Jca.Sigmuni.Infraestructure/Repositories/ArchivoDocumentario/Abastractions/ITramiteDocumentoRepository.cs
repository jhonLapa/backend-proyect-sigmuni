using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions
{
    public interface ITramiteDocumentoRepository : IRepositoryCrud<TramiteDocumento, int>, IRepositoryPaginated<TramiteDocumento>
    {
        public Task<IList<TramiteDocumento>> FindXNumeroAnio(string Numero, string Anio);
        Task<TramiteDocumento> ObtenerUltimoNumeroTramiteDo();
    }
}
