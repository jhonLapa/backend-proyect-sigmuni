using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoOtraInstalacionRepository : ITipoOtraInstalacionRepository
    {
        private readonly ApplicationDbContext _context;
        public TipoOtraInstalacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TipoOtraInstalacion?> BuscarPorCodigoAsync(string codigo)
        => await _context.TipoOtraInstalaciones.Where(e => e.Estado == true && e.Codigo == codigo)
           .FirstOrDefaultAsync();

        public async Task<IList<TipoOtraInstalacion>> FindAll()
        => await _context.TipoOtraInstalaciones.Where(e => e.Estado == true)
           .ToListAsync();
    }
}
