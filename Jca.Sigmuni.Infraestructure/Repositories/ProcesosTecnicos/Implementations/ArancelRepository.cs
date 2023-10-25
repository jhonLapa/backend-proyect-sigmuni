using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Domain.Vias;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class ArancelRepository : IArancelRepository { 
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Arancel> _paginator;

        public ArancelRepository(ApplicationDbContext context, IPaginator<Arancel> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

         public async Task<Arancel> Create(Arancel entity)
        {
            _context.Aranceles.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
         }
        public async Task<Arancel> BuscarPorIdViaAsync(string idVia)
        => await _context.Aranceles.Where(e => e.IdVia == idVia).FirstOrDefaultAsync();
        public async Task<Arancel> BuscarPorIdManzanaAsync(string idManzana)
       => await _context.Aranceles.Where(e => e.IdManzana == idManzana).FirstOrDefaultAsync();
        public async Task<Arancel> BuscarPorIdManzanaIdViaAsync(string idManzana, string idVia)
       => await _context.Aranceles.Where(e => (e.IdManzana == idManzana) && (e.IdVia == idVia)).FirstOrDefaultAsync();

        public async Task<Arancel?> Edit(int id, Arancel entity)
        {
           var model = await _context.Aranceles.FindAsync(id);

           if (model != null)
           {
              model.Anio = entity.Anio;
              model.IdVia = entity.IdVia;
             model.IdManzana = entity.IdManzana;
             model.Valor = entity.Valor;
             model.Estado = entity.Estado;

             _context.Aranceles.Update(model);
             await _context.SaveChangesAsync();
            }

             return model;
        }

    public async Task<Arancel?> Find(int id)
    => await _context.Aranceles
                        .Include(e => e.Manzana).ThenInclude(x => x.Sector)
                        .Include(e => e.Via).ThenInclude(x => x.TipoVia)
                        .Where(e => e.IdArancel == id).FirstOrDefaultAsync();

    public async Task<IList<Arancel>> FindAll()
    => await _context.Aranceles
            .Where(e => e.Estado == true)
            .ToListAsync();

    public async Task<ResponsePagination<Arancel>> PaginatedSearch(RequestPagination<ArancelBusqueda> entity)
    {
        var filter = entity.Filter;
        var query = _context.Aranceles
        .AsQueryable();
        if (filter != null)
        {
            query = query
                        .Include(e => e.Via).ThenInclude(x => x.TipoVia)
                        .Include(e => e.Manzana).ThenInclude(x => x.Sector)
                        .Where(e => (e.Estado == true) &&
                        (!filter.Anio.HasValue || e.Anio == filter.Anio) &&
                        (string.IsNullOrWhiteSpace(filter.IdManzana) || e.IdManzana.Contains(filter.IdManzana)) &&
                        (string.IsNullOrWhiteSpace(filter.IdVia) || e.IdVia.Contains(filter.IdVia)) &&
                         (string.IsNullOrWhiteSpace(filter.IdSector) || e.Manzana.IdSectorCarto == filter.IdSector) &&
                        (!filter.IdTipoVia.HasValue || e.Via.TipoVia.IdTipoVia == filter.IdTipoVia) &&
                            (!filter.Valor.HasValue || e.Valor == filter.Valor)
                );
        }

            var filterArancel = new Arancel()
            {
                Anio = filter?.Anio,
                Estado = filter?.Estado,
                //IdArancel = filter.IdArancel,
                IdManzana = filter?.IdManzana,
                IdVia = filter?.IdVia,
                Valor= filter?.Valor,
            };

            var entityArancel = new RequestPagination<Arancel>()
            {
                Page= entity.Page,
                PerPage= entity.PerPage,
                Filter = filterArancel
            };


        query = query.OrderByDescending(f => f.Anio).ThenBy(f => f.Manzana.Sector.Codigo).ThenBy(f => f.Manzana.Codigo).ThenBy(f => f.Via.Nombre);

            var response = await _paginator.Paginate(query, entityArancel);

        return response;
    }

}
}
