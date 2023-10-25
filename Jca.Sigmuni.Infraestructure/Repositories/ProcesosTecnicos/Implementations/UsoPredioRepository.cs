using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class UsoPredioRepository : IUsoPredioRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<UsoPredio> _paginator;

        public UsoPredioRepository(ApplicationDbContext context, IPaginator<UsoPredio> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<UsoPredio>> FindAll()
       => await _context.UsoPredios

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
