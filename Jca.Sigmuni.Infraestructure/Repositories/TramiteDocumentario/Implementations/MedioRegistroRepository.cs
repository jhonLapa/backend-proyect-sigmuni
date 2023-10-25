using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class MedioRegistroRepository : IMedioRegistroRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<MedioRegistro> _paginator;

        public MedioRegistroRepository(ApplicationDbContext context, IPaginator<MedioRegistro> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<MedioRegistro>> FindAll()
       => await _context.MedioRegistros

           .Where(e => e.Estado == true)
           .ToListAsync();

        public async Task<MedioRegistro> FindByDescripcion(string descripcion)
       => await _context.MedioRegistros.Where(e=>e.Descripcion== descripcion).FirstOrDefaultAsync();
    }
}