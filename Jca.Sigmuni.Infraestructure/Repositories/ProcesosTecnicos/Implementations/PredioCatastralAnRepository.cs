using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class PredioCatastralAnRepository : IPredioCatastralAnRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<PredioCatastralAn> _paginator;

        public PredioCatastralAnRepository(ApplicationDbContext context, IPaginator<PredioCatastralAn> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<PredioCatastralAn>> FindAll()
       => await _context.PredioCatastralAns

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
