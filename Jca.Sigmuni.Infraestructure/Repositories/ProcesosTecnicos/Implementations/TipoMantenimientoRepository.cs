using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoMantenimientoRepository : ITipoMantenimientoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoMantenimiento> _paginator;

        public TipoMantenimientoRepository(ApplicationDbContext context, IPaginator<TipoMantenimiento> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<IList<TipoMantenimiento>> FindAll()
        => await _context.TipoMantenimientos.Where(e => e.Estado == true)
                                            .ToListAsync();

        public async Task<TipoMantenimiento> BuscarPorCodigoAsync(string codigo)
        => await _context.TipoMantenimientos.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
    }
}
