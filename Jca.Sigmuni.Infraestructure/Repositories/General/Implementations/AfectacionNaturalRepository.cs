using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class AfectacionNaturalRepository : IAfectacionNaturalRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<AfectacionNatural> _paginator;

        public AfectacionNaturalRepository(ApplicationDbContext context, IPaginator<AfectacionNatural> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<AfectacionNatural>> FindAll()
       => await _context.AfectacionNaturales

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
