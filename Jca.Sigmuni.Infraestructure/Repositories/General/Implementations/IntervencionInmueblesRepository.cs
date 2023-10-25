using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class IntervencionInmueblesRepository : IIntervencionInmueblesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<IntervencionInmueble> _paginator;

        public IntervencionInmueblesRepository(ApplicationDbContext context, IPaginator<IntervencionInmueble> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<IntervencionInmueble>> FindAll()
       => await _context.IntervencionInmuebles

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
