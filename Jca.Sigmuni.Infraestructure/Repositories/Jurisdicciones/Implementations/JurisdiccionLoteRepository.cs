using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Jurisdiccion;
using Jca.Sigmuni.Domain.Vias;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Jurisdicciones.Abstraccions;
using Jca.Sigmuni.Infraestructure.Repositories.Vias.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.Jurisdicciones.Implementations
{
    public class JurisdiccionLoteRepository : IJurisdiccionLoteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<JurisdiccionLote> _paginator;

        public JurisdiccionLoteRepository(ApplicationDbContext context, IPaginator<JurisdiccionLote> paginator)
        {
            _context = context;
            _paginator = paginator;
        }
        public Task<JurisdiccionLote> Create(JurisdiccionLote entity)
        {
            throw new NotImplementedException();
        }

        public Task<JurisdiccionLote?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<JurisdiccionLote?> Edit(int id, JurisdiccionLote entity)
        {
            throw new NotImplementedException();
        }

        public Task<JurisdiccionLote?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<JurisdiccionLote>> FindAll()
        => await _context.JurisdiccionLotes

            .Where(e => e.Estado == true)
            .ToListAsync();

        public async Task<ResponsePagination<JurisdiccionLote>> PaginatedSearch(RequestPagination<JurisdiccionLote> entity)
        {

            var filter = entity.Filter;
            var query = _context.JurisdiccionLotes
            .AsQueryable();

            if (filter != null)
            {
                query = query.Include(e => e.Ubigeo).Include(e => e.Lote).Where(e =>
                    e.Estado == true
                    && (string.IsNullOrWhiteSpace(filter.NumeroOficioIcl) || e.NumeroOficioIcl.ToUpper().Contains(filter.NumeroOficioIcl.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.CodigoUbigeo) || e.CodigoUbigeo.ToUpper().Contains(filter.CodigoUbigeo.ToUpper().Trim())));
            }

            query = query.OrderBy(e => e.CodigoUbigeo);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
    }
}
