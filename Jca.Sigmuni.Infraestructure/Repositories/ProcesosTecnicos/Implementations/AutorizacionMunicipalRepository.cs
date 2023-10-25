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
    public class AutorizacionMunicipalRepository : IAutorizacionMunicipalRepository
    {
        private readonly ApplicationDbContext _context;

        public AutorizacionMunicipalRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<AutorizacionMunicipal> BuscarPorIdAsync(int id)
        => await _context.AutorizacionMunicipales.Where(e => e.IdAutMunicipal == id).FirstOrDefaultAsync();

        public async Task<AutorizacionMunicipal> Create(AutorizacionMunicipal entity)
        {
            _context.AutorizacionMunicipales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<AutorizacionMunicipal?> Disable(int id)
        {
            var model = await _context.AutorizacionMunicipales.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.AutorizacionMunicipales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<AutorizacionMunicipal?> Edit(int id, AutorizacionMunicipal entity)
        {
            var model = await _context.AutorizacionMunicipales.FindAsync(id);

            if (model != null)
            {
                model.IdGiroAutorizado = entity.IdGiroAutorizado;
                model.IdActividadVerificada = entity.IdActividadVerificada;
                model.IdFicha = entity.IdFicha;
                


                _context.AutorizacionMunicipales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public Task<AutorizacionMunicipal?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AutorizacionMunicipal>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<AutorizacionMunicipal>> ListarPorIdFichaAsync(int idFicha)
         => await _context.AutorizacionMunicipales.Where(e => e.IdFicha == idFicha).ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.AutorizacionMunicipales.FindAsync(id);

            if (model != null)
            {
                _context.AutorizacionMunicipales.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
