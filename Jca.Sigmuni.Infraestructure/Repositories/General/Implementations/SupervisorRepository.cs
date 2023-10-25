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
    public class SupervisorRepository : ISupervisorRepository
    {
        private readonly ApplicationDbContext _context;

        public SupervisorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Supervisor> Create(Supervisor entity)
        {
            _context.Supervisores.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<Supervisor?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Supervisor?> Edit(int id, Supervisor entity)
        {
            var model = await _context.Supervisores.FindAsync(id);

            if (model != null)
            {
                model.Fecha = entity.Fecha;
                model.IdPersona = entity.IdPersona;
                model.IdFicha = entity.IdFicha;
                model.Firma = entity.Firma;
                model.TieneFirma = entity.TieneFirma;

                _context.Supervisores.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Supervisor?> Find(int id)
        => await _context.Supervisores.DefaultIfEmpty()
                                      .FirstOrDefaultAsync(i => i.IdSupervisor.Equals(id));

        public Task<IList<Supervisor>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.Supervisores.FindAsync(id);

            if (model != null)
            {
                _context.Supervisores.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
