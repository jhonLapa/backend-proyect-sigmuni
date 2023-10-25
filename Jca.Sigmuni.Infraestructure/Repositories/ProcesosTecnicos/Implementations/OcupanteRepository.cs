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
    public class OcupanteRepository : IOcupanteRepository
    {
        private readonly ApplicationDbContext _context;

        public OcupanteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ocupante> Create(Ocupante entity)
        {
            _context.Ocupantes.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<Ocupante?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Ocupante?> Edit(int id, Ocupante entity)
        {
            var model = await _context.Ocupantes.FindAsync(id);

            if (model != null)
            {
                model.IdFicha = entity.IdFicha;
                model.IdCondicionPer = entity.IdCondicionPer;

                _context.Ocupantes.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Ocupante?> Find(int id)
        => await _context.Ocupantes.DefaultIfEmpty()
                                .FirstOrDefaultAsync(i => i.IdFicha.Equals(id));

        public Task<IList<Ocupante>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ocupante>> BuscarPorIdFichaAsync(int idFicha)
        => await _context.Ocupantes.Where(x => x.IdFicha == idFicha).ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.Ocupantes.FindAsync(id);

            if (model != null)
            {
                _context.Ocupantes.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
