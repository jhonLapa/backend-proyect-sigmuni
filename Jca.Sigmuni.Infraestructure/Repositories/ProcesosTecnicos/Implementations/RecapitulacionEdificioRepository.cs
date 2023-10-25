using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class RecapitulacionEdificioRepository : IRecapitulacionEdificioRepository
    {
        private readonly ApplicationDbContext _context;

        public RecapitulacionEdificioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RecapitulacionEdificio> Create(RecapitulacionEdificio entity)
        {
            _context.RecapitulacionEdificios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<RecapitulacionEdificio?> Find(int id)
        => await _context.RecapitulacionEdificios.DefaultIfEmpty()
                                                 .FirstOrDefaultAsync(i => i.Id.Equals(id));

        public Task<IList<RecapitulacionEdificio>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<RecapitulacionEdificio>> ListarPorIdFichaAsync(int idFicha)
        => await _context.RecapitulacionEdificios.Where(e => e.IdFicha == idFicha).ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.RecapitulacionEdificios.FindAsync(id);

            if (model != null)
            {
                _context.RecapitulacionEdificios.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
