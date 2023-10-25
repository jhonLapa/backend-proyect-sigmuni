using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class InformeTecnicoRepository : IInformeTecnicoRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<InformeTecnico> _paginator;

        public InformeTecnicoRepository(ApplicationDbContext context, IPaginator<InformeTecnico> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<InformeTecnico> BuscarSolicitudRegistradaAsync(int idSolicitud, int idTipoInforme)
         => await _context.InformeTecnicos.Where(x => x.IdSolicitud == idSolicitud && x.Estado == true && x.IdTipoInforme == idTipoInforme)
             .FirstOrDefaultAsync();

        public async Task<InformeTecnico> BuscarMaxNumeroCorrelativoAsyn()
        => await _context.InformeTecnicos
                .Where(e => e.Estado == true)
                .OrderByDescending(e => e.Id)
                .FirstOrDefaultAsync();

        public async Task<InformeTecnico> BuscarPorNumeroCorrelativoAsync(string numCorrelativo, int idTipoInforme)
         => await _context.InformeTecnicos.Where(x => x.NumCorrelativo == numCorrelativo && x.IdTipoInforme == idTipoInforme)
             .FirstOrDefaultAsync();

        public async Task<InformeTecnico> BuscarPorIdAsync(int id)
         => await _context.InformeTecnicos.Where(e => e.Id == id).FirstOrDefaultAsync();

        public async Task<InformeTecnico> Create(InformeTecnico entity)
        {
            _context.InformeTecnicos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<InformeTecnico?> Find(int id)
        => await _context.InformeTecnicos
          .Include(x => x.TipoInforme)
          .Include(x => x.Solicitud)
          .Include(x => x.Especialista)
          //.Include(x => x.DocumentoIdentidad)
           .DefaultIfEmpty()
          .FirstOrDefaultAsync(i => i.Id.Equals(id));

        public Task<IList<InformeTecnico>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<InformeTecnico> BuscarInformePorIdSolicitud(int idSolicitud)
        => await _context.InformeTecnicos.Where(e => e.IdSolicitud == idSolicitud && e.Estado == true).FirstOrDefaultAsync(); 

        public async Task<InformeTecnico?> Edit(int id, InformeTecnico entity)
        {
            var model = await _context.InformeTecnicos.FindAsync(id);

            _context.InformeTecnicos.Update(model);
            await _context.SaveChangesAsync();

            return model;
        }


        public async Task<InformeTecnico?> EstadoGeneradoInforme(int id)
        {
            var model = await _context.InformeTecnicos.FindAsync(id);

            if (model != null)
            {
                model.EsInforme = true;
                _context.InformeTecnicos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }


        public async Task<InformeTecnico?> Disable(int id)
        {
            var model = await _context.InformeTecnicos.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;
                _context.InformeTecnicos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<ResponsePagination<InformeTecnico>> PaginatedSearch(RequestPagination<InformeTecnico> entity)
        {
            var filter = entity.Filter;
            var query = _context.InformeTecnicos
                .Include(x => x.TipoInforme)
                .Include(x => x.Especialista)
                .Include(x => x.Solicitud).ThenInclude(x => x.Procedimiento).ThenInclude(x => x.ProcedimientoRequisito)
                .AsQueryable();
            if (filter != null)
            {
                query = query.Where(e => (!filter.Estado.HasValue || e.Estado == filter.Estado)
                && (string.IsNullOrWhiteSpace(filter.NumCorrelativo) || e.NumCorrelativo.ToUpper().Contains(filter.NumCorrelativo.ToUpper().Trim()))

                //&& (!filter.IdTipoTramite.HasValue || e.IdTipoTramite == filter.IdTipoTramite)
                //&& (!filter.IdProcedimiento.HasValue || e.IdProcedimiento == filter.IdProcedimiento)


                );
            }
            query = query.OrderByDescending(e => e.Id);
            var response = await _paginator.Paginate(query, entity);
            return response;
        }

    }
}
