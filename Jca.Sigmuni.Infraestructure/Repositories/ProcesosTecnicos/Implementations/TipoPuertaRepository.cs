using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoPuertaRepository : ITipoPuertaRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoPuerta> _paginator;

        public TipoPuertaRepository(ApplicationDbContext context, IPaginator<TipoPuerta> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoPuerta>> FindAll()
       => await _context.TipoPuertas

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
