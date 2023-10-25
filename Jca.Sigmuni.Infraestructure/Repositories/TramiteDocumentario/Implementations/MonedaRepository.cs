using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class MonedaRepository : IMonedaRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Moneda> _paginator;

        public MonedaRepository(ApplicationDbContext context, IPaginator<Moneda> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<Moneda>> FindAll()
       => await _context.Monedas

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
