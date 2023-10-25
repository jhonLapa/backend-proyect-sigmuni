using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.CompendioNormas.Abastractions
{
    public interface INormaDiaDetalleRepository : IRepositoryCrud<NormaDiaDetalle, int>, IRepositoryPaginated<NormaDiaDetalle>
    {
    }
}
