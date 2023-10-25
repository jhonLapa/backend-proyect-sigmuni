using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class FiliacionEstilisticaRepository : IFiliacionEstilisticaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<FiliacionEstilistica> _paginator;

        public FiliacionEstilisticaRepository(ApplicationDbContext context, IPaginator<FiliacionEstilistica> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<FiliacionEstilistica>> FindAll()
       => await _context.FiliacionEstilisticas

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
