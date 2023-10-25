using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class AntiguedadRepository : IAntiguedadRepository
    {
        private readonly ApplicationDbContext _context;

        public AntiguedadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Antiguedad> Create(Antiguedad entity)
        {
            _context.Antiguedades.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Antiguedad?> Find(int id)
        => await _context.Antiguedades.DefaultIfEmpty()
                                        .FirstOrDefaultAsync(i => i.IdAntiguedad.Equals(id));

        public async Task<IList<Antiguedad>> FindAll()
        => await _context.Antiguedades

            .Where(e => e.Estado == true)
            .ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.Antiguedades.FindAsync(id);

            if (model != null)
            {
                _context.Antiguedades.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<List<Antiguedad>> ListarGlobalAsync()
        => await _context.Antiguedades.Where(e => e.Estado == true).ToListAsync();

        public async Task<Antiguedad?> BuscarPorLimitesAsync(int antiguedad)
        => await _context.Antiguedades.Where(e => e.Estado == true && e.LimiteInferior < antiguedad && e.LimiteSuperior >= antiguedad).FirstOrDefaultAsync();
    }
}
