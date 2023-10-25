using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class TramiteSolicitudRepository : ITramiteSolicitudRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TramiteSolicitud> _paginator;

        public TramiteSolicitudRepository(ApplicationDbContext context, IPaginator<TramiteSolicitud> paginator)
        {
            _context = context;
            _paginator = paginator;
        }   

        public async Task<ResponsePagination<TramiteSolicitud>> PaginatedSearch(RequestPagination<TramiteSolicitud> entity)
        {

            throw new NotImplementedException();
        }
    }
}
