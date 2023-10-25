using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class ObservacionRepository : IObservacionRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Observacion> _paginator;

        public ObservacionRepository(ApplicationDbContext context, IPaginator<Observacion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<Observacion>> FindAll()
       => await _context.Observaciones

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
