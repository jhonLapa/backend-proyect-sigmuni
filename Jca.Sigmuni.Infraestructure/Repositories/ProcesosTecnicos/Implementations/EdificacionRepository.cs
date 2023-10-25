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
    public class EdificacionRepository : IEdificacionRepository
    {
        private readonly ApplicationDbContext _context;

        public EdificacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Edificacion> BuscarPorEdificacionAsync(Edificacion edificacion)
        {
            var response = await _context.Edificaciones
                .Where(e => e.Estado == true
                    && (string.IsNullOrWhiteSpace(edificacion.Nombre) || e.Nombre.Trim().ToUpper() == edificacion.Nombre.Trim().ToUpper())
                    && (string.IsNullOrWhiteSpace(edificacion.Manzana) || e.Manzana.Trim().ToUpper() == edificacion.Manzana.Trim().ToUpper())
                    && (string.IsNullOrWhiteSpace(edificacion.NumLote) || e.NumLote.Trim().ToUpper() == edificacion.NumLote.Trim().ToUpper())
                    && (string.IsNullOrWhiteSpace(edificacion.SubLote) || e.SubLote.Trim().ToUpper() == edificacion.SubLote.Trim().ToUpper())
                    && (string.IsNullOrWhiteSpace(edificacion.LoteUrbano) || e.LoteUrbano.Trim().ToUpper() == edificacion.LoteUrbano.Trim().ToUpper())
                    && e.IdTipoEdificacion == edificacion.IdTipoEdificacion
                    && e.IdTipoAgrupacion == edificacion.IdTipoAgrupacion
                ).FirstOrDefaultAsync();

            return response;
        }

        public async Task<Edificacion> Create(Edificacion entity)
        {
            _context.Edificaciones.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<Edificacion?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Edificacion?> Edit(int id, Edificacion entity)
        {
            var model = await _context.Edificaciones.FindAsync(id);

            if (model != null)
            {
                model.Nombre = entity.Nombre;
                model.Manzana = entity.Manzana;
                model.NumLote = entity.NumLote;
                model.LoteUrbano = entity.LoteUrbano;
                model.SubLote = entity.SubLote;
                model.IdTipoEdificacion = entity.IdTipoEdificacion;
                model.IdTipoAgrupacion = entity.IdTipoAgrupacion;

                _context.Edificaciones.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Edificacion?> Find(int id)
        => await _context.Edificaciones.DefaultIfEmpty()
                .FirstOrDefaultAsync(i => i.IdEdificacion.Equals(id));

        public Task<IList<Edificacion>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Edificacion?> EdificacionDefaultAsync()
        => await _context.Edificaciones
            .Where(e => e.Nombre.Trim().ToUpper().Contains("NO DEFINIDO") || e.Nombre.Trim().ToUpper().Contains("NO TIENE"))
            .FirstOrDefaultAsync();
    }
}
