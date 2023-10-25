using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class TiempoConstruccionRepository : ITiempoConstruccionRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TiempoConstruccion> _paginator;

        public TiempoConstruccionRepository(ApplicationDbContext context, IPaginator<TiempoConstruccion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TiempoConstruccion>> FindAll()
       => await _context.TiempoConstrucciones

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
