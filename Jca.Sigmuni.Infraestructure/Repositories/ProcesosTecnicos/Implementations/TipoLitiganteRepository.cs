using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoLitiganteRepository : ITipoLitiganteRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoLitigante> _paginator;

        public TipoLitiganteRepository(ApplicationDbContext context, IPaginator<TipoLitigante> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoLitigante>> FindAll()
       => await _context.TipoLitigantes

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
