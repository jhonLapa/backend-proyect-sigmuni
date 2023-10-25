using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class ProcedimientoNormaInteresRepository : IProcedimientoNormaInteresRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<ProcedimientoNormaInteres> _paginator;

        public ProcedimientoNormaInteresRepository(ApplicationDbContext context, IPaginator<ProcedimientoNormaInteres> paginator)
        { 
            _context= context;
            _paginator= paginator;  
        }

        public async Task<ProcedimientoNormaInteres> BuscarProcedimientoNormaInterePorIdAsync(int idProcedimiento, int norma)
        => await _context.ProcedimientoNormaIntereses.Where(e => e.IdProcedimiento == idProcedimiento && e.IdNormaInteres == norma).FirstOrDefaultAsync();

        public Task<ProcedimientoNormaInteres> Create(ProcedimientoNormaInteres entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProcedimientoNormaInteres?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProcedimientoNormaInteres?> Edit(int id, ProcedimientoNormaInteres entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProcedimientoNormaInteres?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ProcedimientoNormaInteres>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePagination<ProcedimientoNormaInteres>> PaginatedSearch(RequestPagination<ProcedimientoNormaInteres> entity)
        {
            throw new NotImplementedException();
        }
    }
}
