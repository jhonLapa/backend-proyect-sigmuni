using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class CategoriaInmuebleRepository : ICategoriaInmuebleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<CategoriaInmueble> _paginator;

        public CategoriaInmuebleRepository(ApplicationDbContext context, IPaginator<CategoriaInmueble> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<CategoriaInmueble>> FindAll()
       => await _context.CategoriaInmuebles

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
