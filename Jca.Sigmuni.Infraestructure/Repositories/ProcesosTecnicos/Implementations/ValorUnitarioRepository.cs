using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Implementations;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class ValorUnitarioRepository : IValorUnitarioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<ValorUnitario> _paginator;

        public ValorUnitarioRepository(ApplicationDbContext context, IPaginator<ValorUnitario> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<ValorUnitario> Create(ValorUnitario entity)
        {
            _context.ValorUnitarios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<ValorUnitario?> Disable(int id)
        {
            var model = await _context.ValorUnitarios.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.ValorUnitarios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<ValorUnitario?> Edit(int id, ValorUnitario entity)
        {
            var model = await _context.ValorUnitarios.FindAsync(id);

            if (model != null)
            {
                model.Anio = entity.Anio;
                model.Descripcion = entity.Descripcion;
                model.Valor = entity.Valor;
                model.IdClasificacionValUnitario = entity.IdClasificacionValUnitario;
                model.IdCategoriaValUnitario = entity.IdCategoriaValUnitario;
                model.Estado = entity.Estado;

                _context.ValorUnitarios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<ValorUnitario?> Find(int id)
        => await _context.ValorUnitarios.Include(e => e.ClasificacionValorUnitario)
                                        .Include(e => e.CategoriaValorUnitario)
                                        .DefaultIfEmpty()
                                        .FirstOrDefaultAsync(i => i.IdValorUnitario.Equals(id));

        public Task<IList<ValorUnitario>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponsePagination<ValorUnitario>> PaginatedSearch(RequestPagination<ValorUnitario> entity)
        {
            var filter = entity.Filter;
            var query = _context.ValorUnitarios.Include(e => e.ClasificacionValorUnitario).Include(e => e.CategoriaValorUnitario)
            .AsQueryable();
            if (filter != null)
            {
                var estado = filter.Estado == null ? true : filter.Estado;
                query = query
                            .Include(e => e.ClasificacionValorUnitario)
                            .Include(e => e.CategoriaValorUnitario)
                            .Where(e => (e.Estado == estado) &&
                            (!filter.IdClasificacionValUnitario.HasValue || e.IdClasificacionValUnitario == filter.IdClasificacionValUnitario) &&
                            (!filter.IdCategoriaValUnitario.HasValue || e.IdCategoriaValUnitario == filter.IdCategoriaValUnitario) &&
                            (string.IsNullOrWhiteSpace(filter.Descripcion) || e.Descripcion.ToUpper().Contains(filter.Descripcion.ToUpper())) &&
                            (!filter.Anio.HasValue || e.Anio == filter.Anio) &&
                            (!filter.Valor.HasValue || e.Valor == filter.Valor)
                );
            }

            query = query.OrderByDescending(e => e.Anio).ThenBy(f => f.ClasificacionValorUnitario.Codigo).ThenBy(f => f.CategoriaValorUnitario.Codigo);

            var response = await _paginator.Paginate(query, entity);

            return response;
        }

        public async Task<ValorUnitario?> BuscarPorClasificacionCategoria(int idClasificacion, int idCategoria, int anio)
        => await _context.ValorUnitarios.Where(x => x.IdClasificacionValUnitario == idClasificacion &&
                                                    x.IdCategoriaValUnitario == idCategoria && x.Anio == anio)
                                        .FirstOrDefaultAsync();
    }
}
