using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class EstadoLlenadoRepository : IEstadoLlenadoRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<EstadoLlenado> _paginator;

        public EstadoLlenadoRepository(ApplicationDbContext context, IPaginator<EstadoLlenado> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<EstadoLlenado>> FindAll()
       => await _context.EstadoLlenados

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
