using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.Admins.Implementations
{
    public class DomicilioRepository : IDomicilioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Domicilio> _paginator;

        public DomicilioRepository(ApplicationDbContext context, IPaginator<Domicilio> paginator)
        {
            _context = context;
            _paginator = paginator;
        }
        public async Task<Domicilio> Create(Domicilio entity)
        {
            _context.Domicilios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Domicilio?> Disable(int id)
        {
            var model = await _context.Domicilios.FindAsync(id);

            if (model != null)
            {
                model.Estado = !model.Estado;

                _context.Domicilios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Domicilio?> Edit(int id, Domicilio entity)
        {
            var model = await _context.Domicilios.FindAsync(id);

            if (model != null)
            {
                model.NumMunicipal = entity.NumMunicipal;
                model.LtPrincipal = entity.LtPrincipal;
                model.Estado = entity.Estado;
                model.CasillaPostal = entity.CasillaPostal;
                //model.IdVia = entity.IdVia;
                model.CodigoUbigeo = entity.CodigoUbigeo;
                model.IdDenominacionInterior = entity.IdDenominacionInterior;
                model.IdTipoVia = entity.IdTipoVia;
                model.IdTipoHU = entity.IdTipoHU;
                model.IdLoteCarto = entity.IdLoteCarto;
                model.NombreVia = entity.NombreVia;
                model.NombreHU = entity.NombreHU;
                model.LtInterior = entity.LtInterior;

                _context.Domicilios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Domicilio?> Find(int id)
        {
            return await _context.Domicilios.FindAsync(id);
        }

        public async Task<IList<Domicilio>> FindAll()
        {
            return await _context.Domicilios.OrderByDescending(e => e.IdDomicilio).ToListAsync();
        }

        public async Task<ResponsePagination<Domicilio>> PaginatedSearch(RequestPagination<Domicilio> entity)
        {
            var filter = entity.Filter;
            var query = _context.Domicilios.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (string.IsNullOrWhiteSpace(filter.NombreVia) || e.NombreVia == filter.NombreVia)
                    && (string.IsNullOrWhiteSpace(filter.NombreHU) || e.NombreHU.ToUpper().Contains(filter.NombreHU.ToUpper().Trim()))
                );
            }

            query = query.OrderByDescending(e => e.IdDomicilio);

            var response = await _paginator.Paginate(query, entity);

            return response;
        }

        public async Task<Domicilio?> BusquedaSimplePorIdPersonaAsync(int idPersona)
        => await _context.Domicilios
            .Include(e => e.Ubigeo)
            .Include(e => e.TipoInterior)
            .Include(e => e.Edificacion).ThenInclude(f => f.TipoEdificacion)
            .Include(e => e.Edificacion).ThenInclude(f => f.TipoAgrupacion)
            .Where(e => e.IdPersona == idPersona).FirstOrDefaultAsync();

        public  async Task<Domicilio> BuscarPorIdAsync(int id)
       => await _context.Domicilios.Where(e => e.IdDomicilio == id).FirstOrDefaultAsync();
    }
}
