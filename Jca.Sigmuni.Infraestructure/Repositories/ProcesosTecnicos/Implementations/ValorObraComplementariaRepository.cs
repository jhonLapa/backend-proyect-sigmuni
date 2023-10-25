using Jca.Sigmuni.Core.Paginations;
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
    public class ValorObraComplementariaRepository : IValorObraComplementariaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<ValorObraComplementaria> _paginator;

        public ValorObraComplementariaRepository(ApplicationDbContext context, IPaginator<ValorObraComplementaria> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<ValorObraComplementaria?> BuscarPorTipoOtrasInstalaciones(int anio, string descripcion, int idTipo, string unidadMedida, decimal valor, int item)
        => await _context.ValorObraComplementarias.Where(x => x.Anio == anio &&
                                                           x.Descripcion == descripcion &&
                                                           x.IdTipoOtrasInstalaciones == idTipo &&
                                                           x.UnidadMedida == unidadMedida &&
                                                           x.Valor == valor &&
                                                           x.Item == item).FirstOrDefaultAsync();

        public async Task<ValorObraComplementaria> Create(ValorObraComplementaria entity)
        {
            _context.ValorObraComplementarias.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<ValorObraComplementaria?> Disable(int id)
        {
            var model = await _context.ValorObraComplementarias.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.ValorObraComplementarias.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<ValorObraComplementaria?> Edit(int id, ValorObraComplementaria entity)
        {
            var model = await _context.ValorObraComplementarias.FindAsync(id);

            if (model != null)
            {
                model.Anio = entity.Anio;
                model.Descripcion = entity.Descripcion;
                model.Valor = entity.Valor;
                model.UnidadMedida = entity.UnidadMedida;
                model.Item = entity.Item;
                model.IdTipoOtrasInstalaciones = entity.IdTipoOtrasInstalaciones;
                model.FechaRegistro = entity.FechaRegistro;
                model.Estado = entity.Estado;

                _context.ValorObraComplementarias.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<ValorObraComplementaria?> Find(int id)
        => await _context.ValorObraComplementarias.Include(e => e.TipoOtraInstalacion)
                                                  .DefaultIfEmpty()
                                                  .FirstOrDefaultAsync(i => i.Id.Equals(id));

        public Task<IList<ValorObraComplementaria>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponsePagination<ValorObraComplementaria>> PaginatedSearch(RequestPagination<ValorObraComplementaria> entity)
        {
            var filter = entity.Filter;
            var query = _context.ValorObraComplementarias.Include(e => e.TipoOtraInstalacion)
            .AsQueryable();
            if (filter != null)
            {
                var estado = filter.Estado == null ? true : filter.Estado;
                query = query
                            .Include(e => e.TipoOtraInstalacion)
                            .Where(e => (e.Estado == estado) &&
                            (!filter.IdTipoOtrasInstalaciones.HasValue || e.IdTipoOtrasInstalaciones == filter.IdTipoOtrasInstalaciones) &&
                            (string.IsNullOrWhiteSpace(filter.UnidadMedida) || e.UnidadMedida.ToUpper().Contains(filter.UnidadMedida.ToUpper())) &&
                            (!filter.Anio.HasValue || e.Anio == filter.Anio) &&
                            (!filter.Valor.HasValue || e.Valor == filter.Valor)
                );
            }

            query = query.OrderBy(e => e.Anio).ThenBy(f => f.Item);

            var response = await _paginator.Paginate(query, entity);

            return response;
        }

        public async Task<ValorObraComplementaria?> BuscarPorIdTipoAsync(int idTipo)
        => await _context.ValorObraComplementarias.Where(x => x.TipoOtraInstalacion.IdTipoOtraInstalacion == idTipo).FirstOrDefaultAsync();
    }
}
