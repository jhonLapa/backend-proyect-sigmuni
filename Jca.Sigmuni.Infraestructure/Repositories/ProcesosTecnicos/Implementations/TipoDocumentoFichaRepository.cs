using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoDocumentoFichaRepository : ITipoDocumentoFichaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoDocumentoFicha> _paginator;

        public TipoDocumentoFichaRepository(ApplicationDbContext context, IPaginator<TipoDocumentoFicha> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoDocumentoFicha>> FindAll()
       => await _context.TipoDocumentoFichas

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
