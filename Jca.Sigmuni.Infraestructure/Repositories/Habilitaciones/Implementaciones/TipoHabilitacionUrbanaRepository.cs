using Jca.Sigmuni.Domain.Habilitaciones;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.Habilitaciones.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.Habilitaciones.Implementaciones
{
    public class TipoHabilitacionUrbanaRepository : ITipoHabilitacionUrbanaRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoHabilitacionUrbanaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<TipoHabilitacionUrbana> Create(TipoHabilitacionUrbana entity)
        {
            throw new NotImplementedException();
        }

        public Task<TipoHabilitacionUrbana?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TipoHabilitacionUrbana?> Edit(int id, TipoHabilitacionUrbana entity)
        {
            throw new NotImplementedException();
        }

        public Task<TipoHabilitacionUrbana?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<TipoHabilitacionUrbana>> FindAll()
        => await _context.TipoHabilitacionUrbanas

            .Where(e => e.Estado == true)
            .ToListAsync();
    }
}
