using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoEdificacionRepository : ITipoEdificacionRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoEdificacion> _paginator;

        public TipoEdificacionRepository(ApplicationDbContext context, IPaginator<TipoEdificacion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoEdificacion>> FindAll()
       => await _context.TipoEdificaciones

           .Where(e => e.Estado == true)
           .ToListAsync();

        public async Task<TipoEdificacion?> TipoEdificacionDefaultAsync()
        => await _context.TipoEdificaciones
            .Where(e => e.Descripcion.Trim().ToUpper().Contains("NO DEFINIDO") || e.Descripcion.Trim().ToUpper().Contains("NO TIENE"))
            .FirstOrDefaultAsync();

    }
}
