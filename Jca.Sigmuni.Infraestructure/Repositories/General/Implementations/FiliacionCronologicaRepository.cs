using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class FiliacionCronologicaRepository : IFiliacionCronologicaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<FiliacionCronologica> _paginator;

        public FiliacionCronologicaRepository(ApplicationDbContext context, IPaginator<FiliacionCronologica> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<FiliacionCronologica>> FindAll()
       => await _context.FiliacionCronologicas

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
