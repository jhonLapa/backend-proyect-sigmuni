using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class EdificacionIndustrialRepository : IEdificacionIndustrialRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<EdificacionIndustrial> _paginator;

        public EdificacionIndustrialRepository(ApplicationDbContext context, IPaginator<EdificacionIndustrial> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<EdificacionIndustrial>> FindAll()
       => await _context.EdificacionIndustriales

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
