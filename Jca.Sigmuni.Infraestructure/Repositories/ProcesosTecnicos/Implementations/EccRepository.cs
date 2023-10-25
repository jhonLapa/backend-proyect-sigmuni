using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class EccRepository : IEccRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Ecc> _paginator;

        public EccRepository(ApplicationDbContext context, IPaginator<Ecc> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<Ecc>> FindAll()
       => await _context.Eccs

           .Where(e => e.Estado == true).OrderBy(e => e.Codigo)
           .ToListAsync();



    }
}
