using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class MepRepository : IMepRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Mep> _paginator;

        public MepRepository(ApplicationDbContext context, IPaginator<Mep> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<Mep>> FindAll()
       => await _context.Meps

           .Where(e => e.Estado == true).OrderBy(e => e.Codigo)
           .ToListAsync();



    }
}
