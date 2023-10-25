using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class EvaluacionPredioCatastralRepository : IEvaluacionPredioCatastralRepository
    {
        private readonly ApplicationDbContext _context;

        public EvaluacionPredioCatastralRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EvaluacionPredioCatastral> Create(EvaluacionPredioCatastral entity)
        {
            _context.EvaluacionPredioCatastrales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<EvaluacionPredioCatastral?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EvaluacionPredioCatastral?> Edit(int id, EvaluacionPredioCatastral entity)
        {
            var model = await _context.EvaluacionPredioCatastrales.FindAsync(id);

            if (model != null)
            {
                model.PredioCatastralOmiso = entity.PredioCatastralOmiso;
                model.PredioCatastralSubEvaluado = entity.PredioCatastralSubEvaluado;
                model.PredioCatastralSobreEvaluado = entity.PredioCatastralSobreEvaluado;
                model.PredioCatastralConforme = entity.PredioCatastralConforme;
                model.IdFicha = entity.IdFicha;

                _context.EvaluacionPredioCatastrales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<EvaluacionPredioCatastral?> Find(int id)
        => await _context.EvaluacionPredioCatastrales.DefaultIfEmpty()
                                .FirstOrDefaultAsync(i => i.Id.Equals(id));

        public Task<IList<EvaluacionPredioCatastral>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
