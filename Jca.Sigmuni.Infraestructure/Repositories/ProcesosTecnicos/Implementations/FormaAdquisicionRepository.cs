using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class FormaAdquisicionRepository : IFormaAdquisicionRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<FormaAdquisicion> _paginator;

        public FormaAdquisicionRepository(ApplicationDbContext context, IPaginator<FormaAdquisicion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<FormaAdquisicion>> FindAll()
       => await _context.FormaAdquisiciones

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
