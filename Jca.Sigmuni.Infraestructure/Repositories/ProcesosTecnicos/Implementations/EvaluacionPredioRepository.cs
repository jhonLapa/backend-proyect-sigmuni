using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class EvaluacionPredioRepository : IEvaluacionPredioRepository
    {
        private readonly ApplicationDbContext _context;

        public EvaluacionPredioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EvaluacionPredio> Create(EvaluacionPredio entity)
        {
            _context.EvaluacionPredios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<EvaluacionPredio?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EvaluacionPredio?> Edit(int id, EvaluacionPredio entity)
        {
            var model = await _context.EvaluacionPredios.FindAsync(id);

            if (model != null)
            {
                model.Area = entity.Area;
                model.IdTipoEvaluacion = entity.IdTipoEvaluacion;
                model.IdFicha = entity.IdFicha;

                _context.EvaluacionPredios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<EvaluacionPredio?> Find(int id)
        => await _context.EvaluacionPredios.DefaultIfEmpty()
                                           .FirstOrDefaultAsync(i => i.IdEvaluacionPredio.Equals(id));

        public Task<IList<EvaluacionPredio>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
