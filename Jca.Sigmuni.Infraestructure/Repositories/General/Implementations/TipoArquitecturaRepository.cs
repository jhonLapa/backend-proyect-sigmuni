using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class TipoArquitecturaRepository : ITipoArquitecturaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoArquitectura> _paginator;

        public TipoArquitecturaRepository(ApplicationDbContext context, IPaginator<TipoArquitectura> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoArquitectura>> FindAll()
       => await _context.TipoArquitecturas

           .Where(e => e.Estado == true)
           .ToListAsync();

        public async Task<IList<TipoArquitectura>> FindAllPorGrupo(string grupo)
        => await _context.TipoArquitecturas

           .Where(e => (e.Estado == true)&&(e.Grupo==grupo))
           .ToListAsync();
    }
}
