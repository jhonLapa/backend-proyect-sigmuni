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
    public class SunarpRepository : ISunarpRepository
    {
        private readonly ApplicationDbContext _context;

        public SunarpRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sunarp>> ListarPorIdFichaAsync(int idFicha)
        => await _context.Sunarps.Where(e => e.IdFicha == idFicha).ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.Sunarps.FindAsync(id);

            if (model != null)
            {
                _context.Sunarps.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<Sunarp> Create(Sunarp entity)
        {
            _context.Sunarps.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<Sunarp?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Sunarp>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
