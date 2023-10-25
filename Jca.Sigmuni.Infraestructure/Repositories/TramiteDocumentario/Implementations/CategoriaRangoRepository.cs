using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using Newtonsoft.Json.Linq;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class CategoriaRangoRepository : ICategoriaRangoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<CategoriaRango> _paginator;

        public CategoriaRangoRepository(ApplicationDbContext context, IPaginator<CategoriaRango> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<CategoriaRango> Create(CategoriaRango entity)
        {
            _context.CategoriaRangos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<CategoriaRango?> Disable(int id)
        {
            var model = await _context.CategoriaRangos.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.CategoriaRangos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }



        public async Task<CategoriaRango?> Edit(int id, CategoriaRango entity)
        {
            var model = await _context.CategoriaRangos.FindAsync(id);

            //if (model != null)
            //{
            //    model.NumeroDoc = entity.NumeroDoc;
            //    model.NumeroRuc = entity.NumeroRuc;
            //    model.Nombre = entity.Nombre;

            //    _context.CategoriaRangos.Update(model);
            //    await _context.SaveChangesAsync();
            //}

            _context.CategoriaRangos.Update(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<List<CategoriaRango>> ObtenerCategoriaRangoxProcedimiento(int id, int anio)
      => await _context.CategoriaRangos
          .Include(e => e.Procedimiento)
            .ThenInclude(f => f.TipoTramite)
          .Include(e => e.Procedimiento).ThenInclude(f => f.ProcedimientoRequisito)
          .Include(e => e.Categoria)
          .Include(e => e.Rango)
          .Where(e => e.IdProcedimiento == id && e.Anio == anio && e.Estado == true)
          .ToListAsync();


        public async Task<CategoriaRango?> Find(int id)
        => await _context.CategoriaRangos
            .Include(x => x.Categoria)
             .Include(x => x.Rango)
            .Include(x => x.Procedimiento).DefaultIfEmpty()
                .FirstOrDefaultAsync(i => i.Id.Equals(id));

        public async Task<IList<CategoriaRango>> FindAll()
       => await _context.CategoriaRangos
           .Include(x => x.Categoria)
           .Include(x => x.Rango)
           .Include(x => x.Procedimiento).Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<CategoriaRango>> PaginatedSearch(RequestPagination<CategoriaRango> entity)
        {

            var filter = entity.Filter;
            var query = _context.CategoriaRangos
                .Include(x => x.Categoria)
                .Include(x => x.Rango)
                .Include(x => x.Procedimiento).ThenInclude(f => f.TipoTramite)

                .AsQueryable();
            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (!filter.IdProcedimiento.HasValue || e.IdProcedimiento == filter.IdProcedimiento)                     
                    //&& (!filter.Procedimiento.IdTipoTramite.HasValue || e.Procedimiento.IdTipoTramite == filter.Procedimiento.IdTipoTramite)
                    );
            }

            query = query.OrderByDescending(e => e.Id);

            var grupos = query.GroupBy(e => new {
                Anio = e.Anio,
                IdProcedimiento = e.IdProcedimiento,
            });




            var objetosUnicos = grupos.Select(g => g.First());

            var response = await _paginator.Paginate(objetosUnicos, entity);
            return response;

        }


    }
}
