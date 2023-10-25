using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class ActividadVerificadaRepository : IActividadVerificadaRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<ActividadVerificada> _paginator;

        public ActividadVerificadaRepository(ApplicationDbContext context, IPaginator<ActividadVerificada> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<ActividadVerificada>> FindAll()
       => await _context.ActividadesVerificadas

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}
