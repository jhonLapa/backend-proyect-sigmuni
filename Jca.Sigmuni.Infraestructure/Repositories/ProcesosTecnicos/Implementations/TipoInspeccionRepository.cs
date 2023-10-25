using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoInspeccionRepository : ITipoInspeccionRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoInspeccion> _paginator;

        public TipoInspeccionRepository(ApplicationDbContext context, IPaginator<TipoInspeccion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoInspeccion>> FindAll()
       => await _context.TipoInspecciones

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
