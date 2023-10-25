using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class CondicionNumeracionRepository : ICondicionNumeracionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<CondicionNumeracion> _paginator;

        public CondicionNumeracionRepository(ApplicationDbContext context, IPaginator<CondicionNumeracion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<CondicionNumeracion>> FindAll()
       => await _context.CondicionNumeraciones

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
