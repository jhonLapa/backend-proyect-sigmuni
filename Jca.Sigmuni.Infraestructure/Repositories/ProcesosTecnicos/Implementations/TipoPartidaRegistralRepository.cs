using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoPartidaRegistralRepository : ITipoPartidaRegistralRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoPartidaRegistral> _paginator;

        public TipoPartidaRegistralRepository(ApplicationDbContext context, IPaginator<TipoPartidaRegistral> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoPartidaRegistral>> FindAll()
       => await _context.TipoPartidaRegistrales

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
