using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class MotivoRepository : IMotivoRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Motivo> _paginator;

        public MotivoRepository(ApplicationDbContext context, IPaginator<Motivo> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<Motivo>> FindAll()
       => await _context.Motivos

           .Where(e => e.Estado == true)
           .ToListAsync();



    }
}