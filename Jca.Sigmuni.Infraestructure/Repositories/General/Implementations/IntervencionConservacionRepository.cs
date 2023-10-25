using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class IntervencionConservacionRepository : IIntervencionConservacionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<IntervencionConservacion> _paginator;

        public IntervencionConservacionRepository(ApplicationDbContext context, IPaginator<IntervencionConservacion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<IntervencionConservacion>> FindAll()
       => await _context.IntervencionConservaciones

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
