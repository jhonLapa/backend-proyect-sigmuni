using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class ConductorRepository : IConductorRepository
    {
        private readonly ApplicationDbContext _context;

        public ConductorRepository(ApplicationDbContext context, IPaginator<Conductor> paginator)
        {
            _context = context;

        }
        public  async Task<Conductor> BuscarPorIdAsync(int id)
        => await _context.Conductores.Where(e => e.IdConductor == id).FirstOrDefaultAsync();

        public async Task<Conductor> BuscarPorIdPersonaAsync(int idPersona)
        => await _context.Conductores.Where(e => e.IdPersona == idPersona).FirstOrDefaultAsync();

        public async Task<Conductor> Create(Conductor entity)
        {
            _context.Conductores.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<Conductor?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Conductor?> Edit(int id, Conductor entity)
        {
            var model = await _context.Conductores.FindAsync(id);

            if (model != null)
            {
                model.NombreComercial = entity.NombreComercial;
                model.IdPersona = entity.IdPersona;
                model.IdFicha = entity.IdFicha;
                model.IdCondicionConductor = entity.IdCondicionConductor;
                model.NombreAsociacion = entity.NombreAsociacion;
                model.NumTrabajadores = entity.NumTrabajadores;
                


                _context.Conductores.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public Task<Conductor?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Conductor>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
