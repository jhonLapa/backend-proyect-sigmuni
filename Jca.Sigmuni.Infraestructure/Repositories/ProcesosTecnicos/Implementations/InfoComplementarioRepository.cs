using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class InfoComplementarioRepository : IInfoComplementarioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<InfoComplementario> _paginator;

        public InfoComplementarioRepository(ApplicationDbContext context, IPaginator<InfoComplementario> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<InfoComplementario> Create(InfoComplementario entity)
        {
            _context.InfoComplementarios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<InfoComplementario?> Edit(int id, InfoComplementario entity)
        {
            var model = await _context.InfoComplementarios.FindAsync(id);

            if (model != null)
            {
                model.NumHabitantes = entity.NumHabitantes;
                model.NumFamilias = entity.NumFamilias;
                model.Observaciones = entity.Observaciones;
                model.IdObservacion = entity.IdObservacion;
                model.IdTipoMantenimiento = entity.IdTipoMantenimiento;
                model.IdEstadoLlenado = entity.IdEstadoLlenado;
                model.IdFicha = entity.IdFicha;
                model.NumComunicacion = entity.NumComunicacion;
                model.IdTipoInspeccion = entity.IdTipoInspeccion;
                model.IdMotivo = entity.IdMotivo;
                model.IdTipoDocumento = entity.IdTipoDocumento;

                _context.InfoComplementarios.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }



        public async Task<InfoComplementario?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<InfoComplementario?> Find(int id)
        => await _context.InfoComplementarios.DefaultIfEmpty()
                                             .FirstOrDefaultAsync(i => i.IdInfoComplementario.Equals(id));

        public async Task<IList<InfoComplementario>> FindAll()
        => await _context.InfoComplementarios

           .Where(e => e.Estado == true)
           .ToListAsync();

        public async Task<ResponsePagination<InfoComplementario>> PaginatedSearch(RequestPagination<InfoComplementario> entity)
        {

            throw new NotImplementedException();

        }
    }
}
