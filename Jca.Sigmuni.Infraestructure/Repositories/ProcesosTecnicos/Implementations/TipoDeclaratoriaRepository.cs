using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoDeclaratoriaRepository : ITipoDeclaratoriaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoDeclaratoria> _paginator;

        public TipoDeclaratoriaRepository(ApplicationDbContext context, IPaginator<TipoDeclaratoria> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<IList<TipoDeclaratoria>> FindAll()
        => await _context.TipoDeclaratorias.Where(e => e.Estado == true)
                                           .ToListAsync();

        public async Task<TipoDeclaratoria?> BuscarPorCodigoAsync(string codigo)
        => await _context.TipoDeclaratorias.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
    }
}
