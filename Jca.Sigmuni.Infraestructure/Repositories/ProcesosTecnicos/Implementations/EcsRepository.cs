using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class EcsRepository : IEcsRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Ecs> _paginator;

        public EcsRepository(ApplicationDbContext context, IPaginator<Ecs> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<Ecs>> FindAll()
       => await _context.Ecss

           .Where(e => e.Estado == true).OrderBy(e => e.Codigo)
           .ToListAsync();



    }
}
