using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class CondicionAnuncioRepository : ICondicionAnuncioRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<CondicionAnuncio> _paginator;

        public CondicionAnuncioRepository(ApplicationDbContext context, IPaginator<CondicionAnuncio> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<CondicionAnuncio>> FindAll()
       => await _context.CondicionAnuncios

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
