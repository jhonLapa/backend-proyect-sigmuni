using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.CompendioNormas.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.CompendioNormas.Implementations
{
    public class NormaInteresRepository : INormaInteresRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<NormaInteres> _paginator;


        public NormaInteresRepository(ApplicationDbContext context, IPaginator<NormaInteres> paginator)
        {
            _context = context;
            _paginator = paginator;
        }
        public async Task<NormaInteres> Create(NormaInteres entity)
        {
            _context.NormaInteres.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<NormaInteres?> Disable(int id)
        {
            var model = await _context.NormaInteres.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.NormaInteres.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<NormaInteres?> Edit(int id, NormaInteres entity)
        {
            var model = await _context.NormaInteres.FindAsync(id);

            if (model != null)
            {
                model.PaginasInteres = entity.PaginasInteres;
                model.observacion = entity.observacion;
                model.ArticuloNormaDerogado = entity.ArticuloNormaDerogado;
                model.ObservacionNormaDerogado = entity.ObservacionNormaDerogado;
                model.IdUsuario = entity.IdUsuario;
                model.IdDocumento = entity.IdDocumento;
                model.IdTipoNorma = entity.IdTipoNorma;
                model.IdNaturaleza = entity.IdNaturaleza;
                model.IdAutoridad = entity.IdAutoridad;
                model.IdEstadoNorma = entity.IdEstadoNorma;
                model.Nombre = entity.Nombre;
                model.Sumilla = entity.Sumilla;
                model.IdTipoNorma = entity.IdTipoNorma;
                model.Estado = entity.Estado;
                model.FechaRegistro = entity.FechaRegistro;

                _context.NormaInteres.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<NormaInteres?> Find(int id)
        => await _context.NormaInteres.Include(x => x.NormaDiaDetalles).Include(x=>x.NormaDerogadas).ThenInclude(x=>x.NormaInteresDerogada)
            .Where(e => e.IdNormaInteres == id && e.Estado == true).FirstOrDefaultAsync();

        public async Task<IList<NormaInteres>> FindAll()
        => await _context.NormaInteres
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.IdNormaInteres)
            .ToListAsync();

        public async Task<ResponsePagination<NormaInteres>> PaginatedSearch(RequestPagination<NormaInteres> entity)
        {
            var filter = entity.Filter;
            var query = _context.NormaInteres.Include(e => e.NormaDiaDetalles).AsQueryable();

            if (filter != null)
            {
                if (filter.IdAutoridad == 0)
                {
                    filter.IdAutoridad = null;
                }

                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (!filter.IdAutoridad.HasValue || e.IdAutoridad == filter.IdAutoridad)
                    && (string.IsNullOrWhiteSpace(filter.Nombre) || e.Nombre.ToUpper().Contains(filter.Nombre.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Sumilla) || e.Sumilla.ToUpper().Contains(filter.Sumilla.ToUpper().Trim()))

                );
            }

            query = query.OrderByDescending(e => e.IdNormaInteres);

            var response = await _paginator.Paginate(query, entity);

            return response;
        }

        public async Task<ResponsePagination<NormaInteres>> PaginatedSearchFiltros(RequestPagination<NormaInteres> entity, string? fechaRegistroDesde, string? fechaRegistroHasta)
        {
            var filter = entity.Filter;
            var query = _context.NormaInteres.Include(e => e.NormaDiaDetalles).AsQueryable();

            if (filter != null)
            {
                if (filter.IdAutoridad == 0)
                {
                    filter.IdAutoridad = null;
                }

                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (!filter.IdAutoridad.HasValue || e.IdAutoridad == filter.IdAutoridad)
                    && (string.IsNullOrWhiteSpace(filter.Nombre) || e.Nombre.ToUpper().Contains(filter.Nombre.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Sumilla) || e.Sumilla.ToUpper().Contains(filter.Sumilla.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(fechaRegistroDesde) || e.FechaRegistro >= Convert.ToDateTime(fechaRegistroDesde))
                    && (string.IsNullOrWhiteSpace(fechaRegistroHasta) || e.FechaRegistro <= Convert.ToDateTime(fechaRegistroHasta).AddDays(1))
                );
            }

            query = query.OrderByDescending(e => e.IdNormaInteres);

            var response = await _paginator.Paginate(query, entity);

            return response;
        }
    }
}
