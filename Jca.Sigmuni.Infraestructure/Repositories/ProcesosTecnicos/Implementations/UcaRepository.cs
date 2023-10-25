using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class UcaRepository : IUcaRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Uca> _paginator;

        public UcaRepository(ApplicationDbContext context, IPaginator<Uca> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<Uca>> FindAll()
       => await _context.Ucas

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
