using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class TipoDocumentoSimpleRepository : ITipoDocumentoSimpleRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoDocumentoSimple> _paginator;

        public TipoDocumentoSimpleRepository(ApplicationDbContext context, IPaginator<TipoDocumentoSimple> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoDocumentoSimple>> FindAll()
       => await _context.tipoDocumentoSimples

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}