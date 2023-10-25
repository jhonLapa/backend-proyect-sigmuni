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
    public class AreaTerrenoInvalidRepository : IAreaTerrenoInvalidRepository
    {
        private readonly ApplicationDbContext _context;

        public AreaTerrenoInvalidRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AreaTerrenoInvalid> Create(AreaTerrenoInvalid entity)
        {
            _context.AreaTerrenoInvalids.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<AreaTerrenoInvalid?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AreaTerrenoInvalid?> Edit(int id, AreaTerrenoInvalid entity)
        {
            var model = await _context.AreaTerrenoInvalids.FindAsync(id);

            if (model != null)
            {
                model.LoteColindante = entity.LoteColindante;
                model.JardinAislamiento = entity.JardinAislamiento;
                model.AreaPublica = entity.AreaPublica;
                model.AreaIntangible = entity.AreaIntangible;
                model.IdFicha = entity.IdFicha;

                _context.AreaTerrenoInvalids.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<AreaTerrenoInvalid?> Find(int id)
        => await _context.AreaTerrenoInvalids.DefaultIfEmpty()
                                .FirstOrDefaultAsync(i => i.IdEvaluacion.Equals(id));

        public Task<IList<AreaTerrenoInvalid>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
