using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class DependienteRepository : IDependienteRepository
    {
        private readonly ApplicationDbContext _context;

        public DependienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Dependiente> Create(Dependiente entity)
        {
            _context.Dependientes.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<Dependiente?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Dependiente?> Edit(int id, Dependiente entity)
        {
            var model = await _context.Dependientes.FindAsync(id);

            if (model != null)
            {
                model.Relacion = entity.Relacion;
                model.IdPersona = entity.IdPersona;
                model.IdTitularCatastral = entity.IdTitularCatastral;
                model.IdLitigante = entity.IdLitigante;

                _context.Dependientes.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Dependiente?> Find(int id)
        => await _context.Dependientes.DefaultIfEmpty()
                                      .FirstOrDefaultAsync(i => i.Id.Equals(id));

        public Task<IList<Dependiente>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Dependiente>> ListarPorIdLitiganteAsync(int idLitigante)
        => await _context.Dependientes.Where(e => e.IdLitigante == idLitigante).ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.Dependientes.FindAsync(id);

            if (model != null)
            {
                _context.Dependientes.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<List<Dependiente>> ListarPorIdTitularCatastralAsync(int idTitularCatastral)
        => await _context.Dependientes.Where(e => e.IdTitularCatastral == idTitularCatastral).ToListAsync();
    }
}
