using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class TipoInformeRepository : ITipoInformeRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoInforme> _paginator;

        public TipoInformeRepository(ApplicationDbContext context, IPaginator<TipoInforme> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoInforme>> FindAll()
       => await _context.TipoInformes

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
