using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class GiroAutorizadoRepository : IGiroAutorizadoRepository
    {
        
            private readonly ApplicationDbContext _context;
            private readonly IPaginator<GiroAutorizado> _paginator;

            public GiroAutorizadoRepository(ApplicationDbContext context, IPaginator<GiroAutorizado> paginator)
            {
                _context = context;
                _paginator = paginator;
            }




            public async Task<IList<GiroAutorizado>> FindAll()
           => await _context.GirosAutorizados

               .Where(e => e.Estado == true)
               .ToListAsync();

            
        
    }
}
