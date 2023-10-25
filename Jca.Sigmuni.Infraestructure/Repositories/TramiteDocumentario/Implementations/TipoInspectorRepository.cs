using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class TipoInspectorRepository : ITipoInspectorRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoInspector> _paginator;

        public TipoInspectorRepository(ApplicationDbContext context, IPaginator<TipoInspector> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoInspector>> FindAll()
       => await _context.TipoInspectors

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
