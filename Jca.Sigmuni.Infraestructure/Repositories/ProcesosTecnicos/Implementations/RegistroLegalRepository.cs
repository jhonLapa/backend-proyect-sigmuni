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
    public class RegistroLegalRepository : IRegistroLegalRepository
    {
        private readonly ApplicationDbContext _context;

        public RegistroLegalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RegistroLegal> Create(RegistroLegal entity)
        {
            _context.RegistroLegales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<RegistroLegal?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<RegistroLegal>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<RegistroLegal>> ListarPorIdFichaAsync(int idFicha)
        => await _context.RegistroLegales.Where(e => e.IdFicha == idFicha).ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.RegistroLegales.FindAsync(id);

            if (model != null)
            {
                _context.RegistroLegales.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
