using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoEvaluacionRepository : ITipoEvaluacionRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoEvaluacion> _paginator;

        public TipoEvaluacionRepository(ApplicationDbContext context, IPaginator<TipoEvaluacion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoEvaluacion>> FindAll()
       => await _context.TipoEvaluaciones

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
