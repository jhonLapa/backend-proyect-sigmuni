using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class CondicionConductorRepository : ICondicionConductorRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<CondicionConductor> _paginator;

        public CondicionConductorRepository(ApplicationDbContext context, IPaginator<CondicionConductor> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<CondicionConductor>> FindAll()
       => await _context.CondicionConductores

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
