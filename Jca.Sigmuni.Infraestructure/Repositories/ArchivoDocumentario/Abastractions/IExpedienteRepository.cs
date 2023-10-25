using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions
{
    public interface IExpedienteRepository : IRepositoryCrud<Expediente, int>, IRepositoryPaginated<Expediente>
    {
        Task<List<Expediente>> FindxInfo(int id);
        Task<Expediente> FindxInforme(int id);

    }
}
