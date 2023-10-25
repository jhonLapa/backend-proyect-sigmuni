using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class TipoMaterialRepository : ITipoMaterialRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoMaterial> _paginator;

        public TipoMaterialRepository(ApplicationDbContext context, IPaginator<TipoMaterial> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoMaterial>> FindAll()
       => await _context.TipoMateriales

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
