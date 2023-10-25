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
    public class NaturalezaRepository:INaturalezaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Naturaleza> _paginator;

        public NaturalezaRepository(ApplicationDbContext context, IPaginator<Naturaleza> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<IList<Naturaleza>> FindAll()
        => await _context.Naturalezas
            .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
