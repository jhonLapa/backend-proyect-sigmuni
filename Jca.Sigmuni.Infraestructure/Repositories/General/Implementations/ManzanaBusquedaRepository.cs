using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class ManzanaBusquedaRepository : IManzanaBusquedaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Manzana> _paginator;

        public ManzanaBusquedaRepository(ApplicationDbContext context, IPaginator<Manzana> paginator)
        {
            _context = context;
            _paginator = paginator;
        }


      

        public async Task<IList<Manzana>> FindAll()
       => await _context.Manzanas
           
           .Where(e => e.Estado == true)
           .OrderByDescending(e => e.Id)
           .ToListAsync();

        public async Task<ResponsePagination<Manzana>> PaginatedSearch(RequestPagination<Manzana> entity)
        {

            var filter = entity.Filter;
            var query = _context.Manzanas
            
            .AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.Codigo) || e.Codigo.ToUpper().Contains(filter.Codigo.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.EstadoNombre) || e.EstadoNombre.ToUpper().Contains(filter.EstadoNombre.ToUpper().Trim()))
                    

                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
    }
}
