using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class ClasificacionPredioRepository : IClasificacionPredioRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<ClasificacionPredio> _paginator;

        public ClasificacionPredioRepository(ApplicationDbContext context, IPaginator<ClasificacionPredio> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<ClasificacionPredio>> FindAll()
       => await _context.ClasificacionPredios

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
