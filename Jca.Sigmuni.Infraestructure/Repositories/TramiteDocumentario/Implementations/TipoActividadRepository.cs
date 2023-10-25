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
    public class TipoActividadRepository : ITipoActiviadadRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoActividad> _paginator;

        public TipoActividadRepository(ApplicationDbContext context, IPaginator<TipoActividad> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<IList<TipoActividad>> FindAll()
        =>await _context.TipoActividades
            .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
