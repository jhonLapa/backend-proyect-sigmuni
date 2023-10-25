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
    public class LinderoPredioRepository : ILinderoPredioRepository
    {
        private readonly ApplicationDbContext _context;

        public LinderoPredioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LinderoPredio> Create(LinderoPredio entity)
        {
            _context.LinderoPredios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<LinderoPredio?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LinderoPredio?> Edit(int id, LinderoPredio entity)
        {
            var model = await _context.LinderoPredios.FindAsync(id);

            if (model != null)
            {
                model.MedidaFrenteCampo = entity.MedidaFrenteCampo;
                model.MedidaFrenteTitulo = entity.MedidaFrenteTitulo;
                model.ColindaFrenteCampo = entity.ColindaFrenteCampo;
                model.ColindaFrenteTitulo = entity.ColindaFrenteTitulo;
                model.MedidaDerechaCampo = entity.MedidaDerechaCampo;
                model.MedidaDerechaTitulo = entity.MedidaDerechaTitulo;
                model.ColindaDerechaCampo = entity.ColindaDerechaCampo;
                model.ColindaDerechaTitulo = entity.ColindaDerechaTitulo;
                model.MedidaIzquierdaCampo = entity.MedidaIzquierdaCampo;
                model.MedidaIzquierdaTitulo = entity.MedidaIzquierdaTitulo;
                model.ColindaIzquierdaCampo = entity.ColindaIzquierdaCampo;
                model.ColindaIzquierdaTitulo = entity.ColindaIzquierdaTitulo;
                model.MedidaFondoCampo = entity.MedidaFondoCampo;
                model.MedidaFondoTitulo = entity.MedidaFondoTitulo;
                model.ColindaFondoCampo = entity.ColindaFondoCampo;
                model.ColindaFondoTitulo = entity.ColindaFondoTitulo;

                _context.LinderoPredios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<LinderoPredio?> Find(int id)
        => await _context.LinderoPredios.DefaultIfEmpty()
                                .FirstOrDefaultAsync(i => i.Id.Equals(id));

        public Task<IList<LinderoPredio>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
