using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoAgrupacionRepository : ITipoAgrupacionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoAgrupacion> _paginator;

        public TipoAgrupacionRepository(ApplicationDbContext context, IPaginator<TipoAgrupacion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<TipoAgrupacion?> TipoAgrupacionDefaultAsync()
        => await _context.TipoAgrupaciones
            .Where(e => e.Descripcion.Trim().ToUpper().Contains("NO DEFINIDO") || e.Descripcion.Trim().ToUpper().Contains("NO TIENE"))
            .FirstOrDefaultAsync();

        public async Task<IList<TipoAgrupacion>> FindAll()
      => await _context.TipoAgrupaciones

          .Where(e => e.Estado == true)
          .ToListAsync();
    }
}
