using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class TipoExoneracionRepository : ITipoExoneracionRepository
    {
        private readonly ApplicationDbContext _context;
        
        public TipoExoneracionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<TipoExoneracion>> FindAll()
        => await _context.TipoExoneraciones.OrderByDescending(e => e.IdTipoExoneracion).ToListAsync();
    }
}
