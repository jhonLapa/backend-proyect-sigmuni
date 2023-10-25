using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class CondicionTitularRepository : ICondicionTitularRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<CondicionTitular> _paginator;

        public CondicionTitularRepository(ApplicationDbContext context, IPaginator<CondicionTitular> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<CondicionTitular>> FindAll()
       => await _context.CondicionesTitulares

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
