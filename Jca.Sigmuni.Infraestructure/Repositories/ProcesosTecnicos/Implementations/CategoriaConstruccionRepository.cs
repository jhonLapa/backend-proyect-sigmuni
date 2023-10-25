using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class CategoriaConstruccionRepository : ICategoriaConstruccionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<CategoriaConstruccion> _paginator;

        public CategoriaConstruccionRepository(ApplicationDbContext context, IPaginator<CategoriaConstruccion> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<CategoriaConstruccion>> FindAll()
       => await _context.CategoriaConstrucciones

           .Where(e => e.Estado == true)
           .ToListAsync();

        public async Task<CategoriaConstruccion?> ObtenerPorCodigoAsync(string codigo)
        => await _context.CategoriaConstrucciones.Where(e => e.Codigo == codigo).FirstOrDefaultAsync();
    }
}
