using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoInteriorRepository : ITipoInteriorRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoInterior> _paginator;

        public TipoInteriorRepository(ApplicationDbContext context, IPaginator<TipoInterior> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoInterior>> FindAll()
       => await _context.TipoInteriores

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
