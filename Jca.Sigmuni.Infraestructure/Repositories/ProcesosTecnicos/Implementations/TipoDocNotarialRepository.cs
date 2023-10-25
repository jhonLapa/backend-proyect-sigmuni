using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoDocNotarialRepository : ITipoDocNotarialRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoDocNotarial> _paginator;

        public TipoDocNotarialRepository(ApplicationDbContext context, IPaginator<TipoDocNotarial> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoDocNotarial>> FindAll()
       => await _context.TipoDocNotariales

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
