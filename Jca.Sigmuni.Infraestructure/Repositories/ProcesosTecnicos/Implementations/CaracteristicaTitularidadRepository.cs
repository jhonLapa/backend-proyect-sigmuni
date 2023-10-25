using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class CaracteristicaTitularidadRepository : ICaracteristicaTitularidadRepository
    {
        private readonly ApplicationDbContext _context;

        public CaracteristicaTitularidadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CaracteristicaTitularidad> Create(CaracteristicaTitularidad entity)
        {
            _context.CaracteristicaTitularidades.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<CaracteristicaTitularidad?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CaracteristicaTitularidad?> Edit(int id, CaracteristicaTitularidad entity)
        {
            var model = await _context.CaracteristicaTitularidades.FindAsync(id);

            if (model != null)
            {
                model.IdCondicionTitular = entity.IdCondicionTitular;
                model.IdFormaAdquisicion = entity.IdFormaAdquisicion;
                model.IdExoneracionPredio = entity.IdExoneracionPredio;
                model.CondicionTitularOtros = entity.CondicionTitularOtros;
                model.FormaAdquisicionOtros = entity.FormaAdquisicionOtros;
                model.PorcentajeTitularidad = entity.PorcentajeTitularidad;
                model.FechaAdquisicion = entity.FechaAdquisicion;

                _context.CaracteristicaTitularidades.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<CaracteristicaTitularidad?> Find(int id)
        => await _context.CaracteristicaTitularidades.DefaultIfEmpty()
                                                     .FirstOrDefaultAsync(i => i.IdCaracteristicaTitularidad.Equals(id));

        public Task<IList<CaracteristicaTitularidad>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.CaracteristicaTitularidades.FindAsync(id);

            if (model != null)
            {
                _context.CaracteristicaTitularidades.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

         }
}
