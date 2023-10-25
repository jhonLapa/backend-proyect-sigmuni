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
    public class DescripcionPredioRepository : IDescripcionPredioRepository
    {
        private readonly ApplicationDbContext _context;

        public DescripcionPredioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DescripcionPredio?> BuscarPorIdFichaAsync(int idFicha)
        => await _context.DescripcionPredios.Include(f => f.ClasificacionPredio).Where(x => x.IdFicha == idFicha).FirstOrDefaultAsync();

        public async Task<DescripcionPredio> Create(DescripcionPredio entity)
        {
            _context.DescripcionPredios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<DescripcionPredio?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DescripcionPredio?> Edit(int id, DescripcionPredio entity)
        {
            var model = await _context.DescripcionPredios.FindAsync(id);

            if (model != null)
            {
                model.Estructuracion = entity.Estructuracion;
                model.Zonificacion = entity.Zonificacion;
                model.AreaTitulo = entity.AreaTitulo;
                model.AreaLibre = entity.AreaLibre;
                model.AreaVerificada = entity.AreaVerificada;
                model.AreaDeclarada = entity.AreaDeclarada;
                model.IdClasificacionPredio = entity.IdClasificacionPredio;
                model.IdUsoPredio = entity.IdUsoPredio;
                model.IdPredioCatastralEn = entity.IdPredioCatastralEn;
                model.IdFicha = entity.IdFicha;
                model.ClasfDescOtros = entity.ClasfDescOtros;
                model.PredioCatOtros = entity.PredioCatOtros;
                model.UsoPredioOtros = entity.UsoPredioOtros;

                _context.DescripcionPredios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<DescripcionPredio?> Find(int id)
        => await _context.DescripcionPredios.DefaultIfEmpty()
                                            .FirstOrDefaultAsync(i => i.IdDescripcionPredio.Equals(id));

        public Task<IList<DescripcionPredio>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
