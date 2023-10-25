using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.Zonificaciones;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class DepreciacionRepository : IDepreciacionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Depreciacion> _paginator;

        public DepreciacionRepository(ApplicationDbContext context, IPaginator<Depreciacion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Depreciacion> Create(Depreciacion entity)
        {
            _context.Depreciaciones.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Depreciacion?> Edit(int id, Depreciacion entity)
        {
            var model = await _context.Depreciaciones.FindAsync(id);

            if (model != null)
            {
                model.IdMep = entity.IdMep;
                model.IdEcs = entity.IdEcs;
                model.IdAntiguedad = entity.IdAntiguedad;
                model.Porcentaje = entity.Porcentaje;
                model.IdClasificacionPredio = entity.IdClasificacionPredio;
                model.Estado = entity.Estado;

                _context.Depreciaciones.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Depreciacion?> Find(int id)
        => await _context.Depreciaciones
                            .Include(e => e.Antiguedad)
                            .Include(e => e.Ecs)
                            .Include(e => e.Mep)
                            .Include(e => e.ClasificacionPredio)
                            .Where(e => e.IdDepreciacion == id).FirstOrDefaultAsync();

        public async Task<IList<Depreciacion>> FindAll()
        => await _context.Depreciaciones

            .Where(e => e.Estado == true)
            .ToListAsync();

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.Depreciaciones.FindAsync(id);

            if (model != null)
            {
                _context.Depreciaciones.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
        public async Task<Depreciacion> BuscarPorClasificacionEstadoAntiguedad(int idClasificacion, int idAntiguedad, int idMep, int idEcs)
      => await _context.Depreciaciones.Where(x => x.IdClasificacionPredio == idClasificacion &&
                                                          x.IdAntiguedad == idAntiguedad &&
                                                          x.IdMep == idMep &&
                                                          x.IdEcs == idEcs).FirstOrDefaultAsync();

        public async Task<List<Depreciacion>> ListarPorFiltro(bool estado, int? idClasificacion, int? idAntiguedad, int? idMep, int? idEcs, decimal? porcentaje)
        {
           
            var response = await _context.Depreciaciones
                            .Include(e => e.Antiguedad)
                            .Include(e => e.Ecs)
                            .Include(e => e.Mep)
                            .Include(e => e.ClasificacionPredio)
                            .Where(e => (e.Estado == estado) &&
                            (!idClasificacion.HasValue || e.ClasificacionPredio.IdClasificacionPredio == idClasificacion) &&
                            (!idAntiguedad.HasValue || e.Antiguedad.IdAntiguedad == idAntiguedad) &&
                            (!idMep.HasValue || e.Mep.IdMep == idMep) &&
                            (!idEcs.HasValue || e.Ecs.IdEcs == idEcs) &&
                            (!porcentaje.HasValue || e.Porcentaje == porcentaje)
                    ).OrderBy(x => x.ClasificacionPredio.Codigo).ThenBy(y => y.Antiguedad.PrimeraCondicion).ThenBy(z => z.Mep.Codigo).ThenBy(x => x.Ecs.Codigo)
                    .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return response;
        }

        public async Task<Depreciacion> ObtenerDepreciacionCalculo(int idClasificacionPredio, int? idMep, int? idEcs, int aniosCostruccion)
            => await _context.Depreciaciones
                    .Include(e => e.Antiguedad)
                    .Where(x => x.IdClasificacionPredio == idClasificacionPredio &&
                           (!idMep.HasValue || x.IdMep == idMep) &&
                           (!idEcs.HasValue || x.IdEcs == idEcs) &&
                           x.Antiguedad.LimiteInferior <= aniosCostruccion && aniosCostruccion <= x.Antiguedad.LimiteSuperior).FirstOrDefaultAsync();

       // public ResponsePagination<List<Depreciacion>> PaginatedSearch(RequestPagination<Depreciacion> request)
        public async Task<ResponsePagination<Depreciacion>> PaginatedSearch(RequestPagination<Depreciacion> entity)
        {
            var filter = entity.Filter;
            var query = _context.Depreciaciones
            .AsQueryable();
            if (filter != null)
            {
                query = query
                            .Include(e => e.Antiguedad)
                            .Include(e => e.Ecs)
                            .Include(e => e.Mep)
                            .Include(e => e.ClasificacionPredio)
                            .Where(e => (e.Estado == filter.Estado) &&
                            (!filter.IdClasificacionPredio.HasValue || e.ClasificacionPredio.IdClasificacionPredio == filter.IdClasificacionPredio) &&
                            (!filter.IdAntiguedad.HasValue || e.Antiguedad.IdAntiguedad == filter.IdAntiguedad) &&
                            (!filter.IdMep.HasValue || e.Mep.IdMep == filter.IdMep) &&
                            (!filter.IdEcs.HasValue || e.Ecs.IdEcs == filter.IdEcs) &&
                            (!filter.Porcentaje.HasValue || e.Porcentaje == filter.Porcentaje)
                    );
            }




            query = query.OrderBy(x => x.ClasificacionPredio.Codigo).ThenBy(y => y.Antiguedad.PrimeraCondicion).ThenBy(z => z.Mep.Codigo).ThenBy(x => x.Ecs.Codigo);

            var response = await _paginator.Paginate(query, entity);

            return response;
        }

    }
}
