using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class MedioPagoRepository : IMedioPagoRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<MedioPago> _paginator;

        public MedioPagoRepository(ApplicationDbContext context, IPaginator<MedioPago> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<MedioPago>> FindAll()
       => await _context.MedioPagos

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
