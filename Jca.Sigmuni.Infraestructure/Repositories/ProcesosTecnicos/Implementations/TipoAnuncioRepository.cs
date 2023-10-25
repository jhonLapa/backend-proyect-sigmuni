using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoAnuncioRepository : ITipoAnuncioRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoAnuncio> _paginator;

        public TipoAnuncioRepository(ApplicationDbContext context, IPaginator<TipoAnuncio> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoAnuncio>> FindAll()
       => await _context.TipoAnuncios

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
