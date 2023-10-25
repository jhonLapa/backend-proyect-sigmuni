using Jca.Sigmuni.Domain.ProcesosTecnicos;
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
    public class TipoNormaRepository : ITipoNormaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoNorma> _paginator;

        public TipoNormaRepository(ApplicationDbContext context, IPaginator<TipoNorma> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<IList<TipoNorma>> FindAll()
         => await _context.TipoNormas

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
