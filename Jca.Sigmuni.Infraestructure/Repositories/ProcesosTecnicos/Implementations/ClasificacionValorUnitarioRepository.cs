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
    public class ClasificacionValorUnitarioRepository : IClasificacionValorUnitarioRepository
    {
        private readonly ApplicationDbContext _context;

        public ClasificacionValorUnitarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ClasificacionValorUnitario> Create(ClasificacionValorUnitario entity)
        {
            throw new NotImplementedException();
        }

        public Task<ClasificacionValorUnitario?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClasificacionValorUnitario?> Edit(int id, ClasificacionValorUnitario entity)
        {
            throw new NotImplementedException();
        }

        public Task<ClasificacionValorUnitario?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ClasificacionValorUnitario>> FindAll()
        => await _context.ClasificacionValorUnitarios.Where(e => e.Estado == true)
                                                     .OrderBy(e => e.Codigo)
                                                     .ToListAsync();
    }
}
