using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class TurnoInspeccionRepository : ITurnoInspeccionRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TurnoInspeccion> _paginator;

        public TurnoInspeccionRepository(ApplicationDbContext context, IPaginator<TurnoInspeccion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TurnoInspeccion>> FindAll()
       => await _context.TurnoInspeccions

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
