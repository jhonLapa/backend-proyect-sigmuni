using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class TipoDocumentoPresentadoRepository : ITipoDocumentoPresentadoRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoDocumentoPresentado> _paginator;

        public TipoDocumentoPresentadoRepository(ApplicationDbContext context, IPaginator<TipoDocumentoPresentado> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoDocumentoPresentado>> FindAll()
       => await _context.tipoDocumentoPresentados

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
