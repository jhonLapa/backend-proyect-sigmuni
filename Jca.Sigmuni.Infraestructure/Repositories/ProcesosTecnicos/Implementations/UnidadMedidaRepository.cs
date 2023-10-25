using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<UnidadMedida> _paginator;

        public UnidadMedidaRepository(ApplicationDbContext context, IPaginator<UnidadMedida> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<UnidadMedida>> FindAll()
       => await _context.UnidadMedidas

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
