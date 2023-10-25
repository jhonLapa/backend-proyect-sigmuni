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
    public class TitularCatastralRepository : ITitularCatastralRepository
    {
        private readonly ApplicationDbContext _context;

        public TitularCatastralRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TitularCatastral> Create(TitularCatastral entity)
        {
            _context.TitularCatastrales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<TitularCatastral?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TitularCatastral?> Edit(int id, TitularCatastral entity)
        {
            var model = await _context.TitularCatastrales.FindAsync(id);

            if (model != null)
            {
                model.IdPersona = entity.IdPersona;
                model.IdDomicilio = entity.IdDomicilio;
                model.IdCaracteristicaTitularidad = entity.IdCaracteristicaTitularidad;
                model.IdCondicionPer = entity.IdCondicionPer;
                model.CodContribuyente = entity.CodContribuyente;
                model.Asociacion = entity.Asociacion;
                model.IdFicha = entity.IdFicha;
                model.NumTitularidad = entity.NumTitularidad;

                _context.TitularCatastrales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<TitularCatastral?> Find(int id)
        => await _context.TitularCatastrales.Include(e => e.Dependientes).DefaultIfEmpty()
                                            .FirstOrDefaultAsync(i => i.IdTitularCatastral.Equals(id));

        public Task<IList<TitularCatastral>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<TitularCatastral?> BuscarPorIdFichaYIdCaracteristicaTitularidadAsync(int idFicha, int? idCaracteristicaTitularidad)
        {
            var response = await _context.TitularCatastrales.Where(e => e.IdFicha == idFicha && e.IdCaracteristicaTitularidad == idCaracteristicaTitularidad).FirstOrDefaultAsync();

            if (response == null)
            {
                return null;
            }

            return response;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.TitularCatastrales.FindAsync(id);

            if (model != null)
            {
                _context.TitularCatastrales.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<TitularCatastral> BuscarPorIdAsync(int id)
            => await _context.TitularCatastrales.Where(e => e.IdTitularCatastral == id).FirstOrDefaultAsync();
    }
}
