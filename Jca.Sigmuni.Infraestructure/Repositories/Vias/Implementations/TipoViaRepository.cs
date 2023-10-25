using Jca.Sigmuni.Domain.Vias;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.Vias.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.Vias.Implementations
{
    public class TipoViaRepository : ITipoViaRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoViaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<TipoVia> Create(TipoVia entity)
        {
            throw new NotImplementedException();
        }

        public Task<TipoVia?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TipoVia?> Edit(int id, TipoVia entity)
        {
            throw new NotImplementedException();
        }

        public Task<TipoVia?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<TipoVia>> FindAll()
        => await _context.TipoVias

            .Where(e => e.Estado == true)
            .ToListAsync();
    }
}
