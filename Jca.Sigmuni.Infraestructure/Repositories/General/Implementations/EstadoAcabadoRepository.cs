using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class EstadoAcabadoRepository : IEstadoAcabadoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<EstadoAcabado> _paginator;

        public EstadoAcabadoRepository(ApplicationDbContext context, IPaginator<EstadoAcabado> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<EstadoAcabado>> FindAll()
       => await _context.EstadoAcabados

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
