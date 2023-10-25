using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class TipoDigitacionRepository : ITipoDigitacionRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoDigitacion> _paginator;

        public TipoDigitacionRepository(ApplicationDbContext context, IPaginator<TipoDigitacion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoDigitacion>> FindAll()
       => await _context.TipoDigitacions

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
