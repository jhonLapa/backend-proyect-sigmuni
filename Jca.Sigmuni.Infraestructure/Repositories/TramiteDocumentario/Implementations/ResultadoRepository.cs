using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public  class ResultadoRepository : IResultadoRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Resultado> _paginator;

        public ResultadoRepository(ApplicationDbContext context, IPaginator<Resultado> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<Resultado>> FindAll()
       => await _context.Resultados

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
