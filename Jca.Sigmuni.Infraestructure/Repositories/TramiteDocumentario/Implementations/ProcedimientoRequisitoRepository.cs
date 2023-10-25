using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class ProcedimientoRequisitoRepository : IProcedimientoRequisitoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<CategoriaRango> _paginator;

        public ProcedimientoRequisitoRepository(ApplicationDbContext context, IPaginator<CategoriaRango> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<ProcedimientoRequisito> BuscarProcedimientoRequisitoPorIdProcedimientoIdRequisitoAsync(int idProcedimiento, int idRequisito)
        => await _context.ProcedimientoRequisitos.Where(e => e.IdProcedimiento == idProcedimiento && e.IdRequisito == idRequisito)
         .FirstOrDefaultAsync();

        public async Task<List<ProcedimientoRequisito>> ListarxProcedimientoAsync(int idProcedimiento)
        {
            var response = await _context.ProcedimientoRequisitos
                    .Include(p => p.Procedimiento)
                    .Include(r => r.Requisito)
                    .Where(c => c.IdProcedimiento == idProcedimiento && c.Estado == true)
                    .ToListAsync();

            return response;
        }


        public async Task<ProcedimientoRequisito> Create(ProcedimientoRequisito entity)
        {
            _context.ProcedimientoRequisitos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<ProcedimientoRequisito?> Disable(int id)
        {
            var model = await _context.ProcedimientoRequisitos.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.ProcedimientoRequisitos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }


        public async Task<ProcedimientoRequisito?> Edit(int id, ProcedimientoRequisito entity)
        {
            var model = await _context.ProcedimientoRequisitos.FindAsync(id);

            _context.ProcedimientoRequisitos.Update(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public Task<ProcedimientoRequisito?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ProcedimientoRequisito>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePagination<ProcedimientoRequisito>> PaginatedSearch(RequestPagination<ProcedimientoRequisito> entity)
        {
            throw new NotImplementedException();
        }
    }
}
