using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class ElementoArquitectonicoRepository : IElementoArquitectonicoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<ElementoArquitectonico> _paginator;

        public ElementoArquitectonicoRepository(ApplicationDbContext context, IPaginator<ElementoArquitectonico> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<ElementoArquitectonico>> FindAll()
       => await _context.ElementoArquitectonicos

           .Where(e => e.Estado == true)
           .ToListAsync();
    }
}
