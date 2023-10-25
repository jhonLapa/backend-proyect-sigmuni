using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class PredioCatastralEnRepository : IPredioCatastralEnRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<PredioCatastralEn> _paginator;

        public PredioCatastralEnRepository(ApplicationDbContext context, IPaginator<PredioCatastralEn> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<PredioCatastralEn>> FindAll()
       => await _context.PredioCatastralEns

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
