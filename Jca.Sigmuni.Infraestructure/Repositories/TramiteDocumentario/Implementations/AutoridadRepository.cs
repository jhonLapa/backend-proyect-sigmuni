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
    public class AutoridadRepository : IAutoridadRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Autoridad> _paginator;

        public AutoridadRepository(ApplicationDbContext context, IPaginator<Autoridad> paginator)
        {
            _context = context;
            _paginator = paginator;
        }
    
        public async Task<IList<Autoridad>> FindAll()
            => await _context.Autoridades
             .Where(e => e.Estado == true)
           .ToListAsync();

    }
}
