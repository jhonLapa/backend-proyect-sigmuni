using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoDocumentoObraRepository : ITipoDocumentoObraRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoDocumentoObra> _paginator;

        public TipoDocumentoObraRepository(ApplicationDbContext context, IPaginator<TipoDocumentoObra> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoDocumentoObra>> FindAll()
       => await _context.TipoDocumentoObras

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
