using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class TipoServicioBasicoRepository : ITipoServicioBasicoRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoServicioBasico> _paginator;

        public TipoServicioBasicoRepository(ApplicationDbContext context, IPaginator<TipoServicioBasico> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<TipoServicioBasico>> FindAll()
        => await _context.TipoServicioBasicos

           .Where(e => e.Estado == true)
           .ToListAsync();


        public async Task<List<TipoServicioBasico>> ListarGrupoAsync(string grupo)
        {

            var response = await _context.TipoServicioBasicos.Where(e => (e.Estado == true) &&
                            (string.IsNullOrWhiteSpace(grupo) || e.Grupo.ToUpper().Contains(grupo.ToUpper()))
                    )
                    .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return response;
        }
    }
}
