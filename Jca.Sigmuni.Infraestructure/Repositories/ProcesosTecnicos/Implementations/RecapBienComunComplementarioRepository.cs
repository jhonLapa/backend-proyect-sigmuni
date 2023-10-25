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
    public class RecapBienComunComplementarioRepository : IRecapBienComunComplementarioRepository
    {
        private readonly ApplicationDbContext _context;

        public RecapBienComunComplementarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RecapBienComunComplementario> Create(RecapBienComunComplementario entity)
        {
            _context.RecapBienComunComplementarios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<RecapBienComunComplementario?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RecapBienComunComplementario?> Edit(int id, RecapBienComunComplementario entity)
        {
            throw new NotImplementedException();
        }

        public Task<RecapBienComunComplementario?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<RecapBienComunComplementario>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.RecapBienComunComplementarios.FindAsync(id);

            if (model != null)
            {
                _context.RecapBienComunComplementarios.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<List<RecapBienComunComplementario>> ListarPorIdFichaAsync(int idFicha)
        => await _context.RecapBienComunComplementarios.Where(e => e.IdFicha == idFicha).ToListAsync();
    }
}
