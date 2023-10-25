using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoFichaRepository : ITipoFichaRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoFicha> _paginator;

        public TipoFichaRepository(ApplicationDbContext context, IPaginator<TipoFicha> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoFicha>> FindAll()
       => await _context.TipoFichas

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
