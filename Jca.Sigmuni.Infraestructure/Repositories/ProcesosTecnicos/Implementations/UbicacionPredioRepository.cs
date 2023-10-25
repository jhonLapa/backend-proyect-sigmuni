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
    public class UbicacionPredioRepository : IUbicacionPredioRepository
    {
        private readonly ApplicationDbContext _context;

        public UbicacionPredioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UbicacionPredio> Create(UbicacionPredio entity)
        {
            _context.UbicacionPredios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<UbicacionPredio?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UbicacionPredio?> Edit(int id, UbicacionPredio entity)
        {
            var model = await _context.UbicacionPredios.FindAsync(id);

            if (model != null)
            {
                model.DenominacionPredio = entity.DenominacionPredio;
                model.IdEdificacion = entity.IdEdificacion;
                model.IdHabilitacionUrbana = entity.IdHabilitacionUrbana;
                model.IdFicha = entity.IdFicha;

                _context.UbicacionPredios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<UbicacionPredio?> Find(int id)
        => await _context.UbicacionPredios.DefaultIfEmpty()
            .FirstOrDefaultAsync(i => i.IdUbicacionPredio.Equals(id));

        public Task<IList<UbicacionPredio>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
