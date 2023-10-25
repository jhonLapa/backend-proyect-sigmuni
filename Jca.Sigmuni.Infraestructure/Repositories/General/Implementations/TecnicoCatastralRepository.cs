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
    public class TecnicoCatastralRepository : ITecnicoCatastralRepository
    {
        private readonly ApplicationDbContext _context;

        public TecnicoCatastralRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TecnicoCatastral> Create(TecnicoCatastral entity)
        {
            _context.TecnicoCatastrales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<TecnicoCatastral?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TecnicoCatastral?> Edit(int id, TecnicoCatastral entity)
        {
            var model = await _context.TecnicoCatastrales.FindAsync(id);

            if (model != null)
            {
                model.Fecha = entity.Fecha;
                model.IdPersona = entity.IdPersona;
                model.IdFicha = entity.IdFicha;
                model.Firma = entity.Firma;
                model.TieneFirma = entity.TieneFirma;

                _context.TecnicoCatastrales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<TecnicoCatastral?> Find(int id)
        => await _context.TecnicoCatastrales.DefaultIfEmpty()
                                            .FirstOrDefaultAsync(i => i.IdTecnicoCatastral.Equals(id));

        public Task<IList<TecnicoCatastral>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.TecnicoCatastrales.FindAsync(id);

            if (model != null)
            {
                _context.TecnicoCatastrales.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
