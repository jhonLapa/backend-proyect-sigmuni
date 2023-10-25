using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoTituloInscritoRepository : ITipoTituloInscritoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoTituloInscrito> _paginator;

        public TipoTituloInscritoRepository(ApplicationDbContext context, IPaginator<TipoTituloInscrito> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<IList<TipoTituloInscrito>> FindAll()
        => await _context.TipoTituloInscritos.Where(e => e.Estado == true)
                                             .ToListAsync();

        public async Task<TipoTituloInscrito?> BuscarPorCodigoAsync(string codigo)
        => await _context.TipoTituloInscritos.Where(x => x.Codigo.Trim() == codigo).FirstOrDefaultAsync();
    }
}
