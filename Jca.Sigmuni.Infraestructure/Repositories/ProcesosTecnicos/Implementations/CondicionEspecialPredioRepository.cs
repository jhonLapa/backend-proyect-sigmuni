using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class CondicionEspecialPredioRepository : ICondicionEspecialPredioRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<CondicionEspecialPredio> _paginator;

        public CondicionEspecialPredioRepository(ApplicationDbContext context, IPaginator<CondicionEspecialPredio> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<CondicionEspecialPredio>> FindAll()
       => await _context.condicionEspecialPredios

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
