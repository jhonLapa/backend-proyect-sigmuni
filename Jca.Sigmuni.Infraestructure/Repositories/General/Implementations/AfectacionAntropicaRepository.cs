using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class AfectacionAntropicaRepository : IAfectacionAntropicaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<AfectacionAntropica> _paginator;

        public AfectacionAntropicaRepository(ApplicationDbContext context, IPaginator<AfectacionAntropica> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<AfectacionAntropica>> FindAll()
       => await _context.AfectacionAntropicas

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
