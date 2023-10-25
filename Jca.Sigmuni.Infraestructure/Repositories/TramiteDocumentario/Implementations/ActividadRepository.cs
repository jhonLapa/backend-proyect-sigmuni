using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
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
    public class ActividadRepository : IActividadRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Actividad> _paginator;

        public ActividadRepository(ApplicationDbContext context, IPaginator<Actividad> paginator)
        {
            _context = context;
            _paginator = paginator;            
        }

        public async Task<Actividad> BuscarActividadPorIdProcedimientoAsync(int idProcedimiento, int idActividad)
        => await _context.Actividades.Where(e => e.IdProcedimiento == idProcedimiento && e.Id == idActividad).FirstOrDefaultAsync();

        public async Task<List<Actividad>> BuscarPorIdAccionGenerarAsync(int idAccionGenerar)
        => await _context.Actividades.Where(e => e.IdAccionGenerar == idAccionGenerar && e.Estado == true).ToListAsync();

        public async Task<List<Actividad>> BuscarPorIdTipoActividadAsync(int idTipoActividad)
       => await _context.Actividades.Where(e => e.IdTipoActividad== idTipoActividad && e.Estado == true).ToListAsync();

        public async Task<List<Actividad>> CrearActualizarActividadesMultipleAsync(List<Actividad> actividads, int idProcedimiento)
        {
            throw new NotImplementedException();
        }

        public Task<Actividad> Create(Actividad entity)
        {
            throw new NotImplementedException();
        }

        public Task<Actividad?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Actividad?> Edit(int id, Actividad entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Actividad?> Find(int id)
        => await _context.Actividades
            .Include(x => x.TipoActividad)
            .Include(x => x.Procedimiento)
            .DefaultIfEmpty()
            .FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async Task<IList<Actividad>> FindAll()
        => await _context.Actividades
            .Include(x => x.TipoActividad)
            .Include(x => x.Procedimiento)
            .Where(e => e.Estado == true)
            .ToListAsync();

        public async Task<List<Actividad>> ListarPorIdYCodigoTipoActividadAsync(int idProcedimiento, string codigo)
        => await _context.Actividades.Include(x=> x.TipoActividad).Where(e=>e.TipoActividad.Codigo.Trim()==codigo&& e.IdProcedimiento==idProcedimiento && e.Estado==true).ToListAsync();

        public Task<ResponsePagination<Actividad>> PaginatedSearch(RequestPagination<Actividad> entity)
        {
            throw new NotImplementedException();
        }
    }
}
