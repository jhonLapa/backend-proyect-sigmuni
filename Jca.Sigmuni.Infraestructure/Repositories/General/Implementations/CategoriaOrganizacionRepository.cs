using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class CategoriaOrganizacionRepository : ICategoriaOrganizacionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<CategoriaOrganizacion> _paginator;

        public CategoriaOrganizacionRepository(ApplicationDbContext context, IPaginator<CategoriaOrganizacion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<CategoriaOrganizacion>> FindAll()
       => await _context.CategoriaOrganizaciones

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
