using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class CondicionPerRepository : ICondicionPerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<CondicionPer> _paginator;

        public CondicionPerRepository(ApplicationDbContext context, IPaginator<CondicionPer> paginator)
        {
            _context = context;
            _paginator = paginator;
        }


        public async Task<IList<CondicionPer>> FindAll()
        => await _context.CondicionPers

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
