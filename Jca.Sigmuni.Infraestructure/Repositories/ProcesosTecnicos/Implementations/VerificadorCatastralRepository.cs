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
    public class VerificadorCatastralRepository : IVerificadorCatastralRepository
    {
        private readonly ApplicationDbContext _context;

        public VerificadorCatastralRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VerificadorCatastral> Create(VerificadorCatastral entity)
        {
            _context.VerificadorCatastrales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<VerificadorCatastral?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VerificadorCatastral?> Edit(int id, VerificadorCatastral entity)
        {
            var model = await _context.VerificadorCatastrales.FindAsync(id);

            if (model != null)
            {
                model.IdPersona = entity.IdPersona;
                model.IdCondicionPer = entity.IdCondicionPer;
                model.IdFicha = entity.IdFicha;
                model.NumeroRegistro = entity.NumeroRegistro;
                model.TieneFirma = entity.TieneFirma;
                model.Fecha = entity.Fecha;

                _context.VerificadorCatastrales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<VerificadorCatastral?> Find(int id)
        => await _context.VerificadorCatastrales.DefaultIfEmpty()
                                .FirstOrDefaultAsync(i => i.Id.Equals(id));

        public Task<IList<VerificadorCatastral>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
