using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.CompendioNormas.Abastractions
{
    public interface INormaInteresMenuRepository : IRepositoryCrud<NormaInteresMenu, int>, IRepositoryPaginated<NormaInteresMenu>
    {
        Task<List<NormaInteresMenu>> BuscarPorIdNormaInteres(int idNormaInteresMenu);
    }
}
