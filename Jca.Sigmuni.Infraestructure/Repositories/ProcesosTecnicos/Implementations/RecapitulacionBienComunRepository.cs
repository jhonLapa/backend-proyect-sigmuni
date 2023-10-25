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
    public class RecapitulacionBienComunRepository : IRecapitulacionBienComunRepository
    {
        private readonly ApplicationDbContext _context;

        public RecapitulacionBienComunRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RecapitulacionBienComun> Create(RecapitulacionBienComun entity)
        {
            _context.RecapitulacionBienComunes.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<RecapitulacionBienComun?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RecapitulacionBienComun?> Edit(int id, RecapitulacionBienComun entity)
        {
            throw new NotImplementedException();
        }

        public Task<RecapitulacionBienComun?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<RecapitulacionBienComun>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.RecapitulacionBienComunes.FindAsync(id);

            if (model != null)
            {
                _context.RecapitulacionBienComunes.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<List<RecapitulacionBienComun>> ListarPorIdFichaAsync(int idFicha)
        => await _context.RecapitulacionBienComunes.Where(e => e.IdFicha == idFicha).ToListAsync();
    }
}
