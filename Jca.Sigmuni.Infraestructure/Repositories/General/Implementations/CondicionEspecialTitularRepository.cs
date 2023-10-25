using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class CondicionEspecialTitularRepository : ICondicionEspecialTitularRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<CondicionEspecialTitular> _paginator;

        public CondicionEspecialTitularRepository(ApplicationDbContext context, IPaginator<CondicionEspecialTitular> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<CondicionEspecialTitular>> FindAll()
       => await _context.CondicionEspecialTitulares

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
