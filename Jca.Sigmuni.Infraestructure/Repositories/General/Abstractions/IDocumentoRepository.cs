using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IDocumentoRepository : IRepositoryCrud<Documento, int>, IRepositoryPaginated<Documento>
    {
    }
}
