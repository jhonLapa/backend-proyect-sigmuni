using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class ExoneracionPredioRepository : IExoneracionPredioRepository
    {
        private readonly ApplicationDbContext _context;
        public ExoneracionPredioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExoneracionPredio> Create(ExoneracionPredio entity)
        {
            _context.ExoneracionPredios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<ExoneracionPredio?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ExoneracionPredio?> Edit(int id, ExoneracionPredio entity)
        {
            var model = await _context.ExoneracionPredios.FindAsync(id);

            if (model != null)
            {
                model.IdCondicionEspecialPredio = entity.IdCondicionEspecialPredio;
                model.NumeroResolucion = entity.NumeroResolucion;
                model.Porcentaje = entity.Porcentaje;
                model.FechaInicio = entity.FechaInicio;
                model.FechaVencimiento = entity.FechaVencimiento;
                model.AnioResolucion = entity.AnioResolucion;

                _context.ExoneracionPredios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<ExoneracionPredio?> Find(int id)
        => await _context.ExoneracionPredios.DefaultIfEmpty()
                                            .FirstOrDefaultAsync(i => i.IdExoneracionPredio.Equals(id));

        public Task<IList<ExoneracionPredio>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
