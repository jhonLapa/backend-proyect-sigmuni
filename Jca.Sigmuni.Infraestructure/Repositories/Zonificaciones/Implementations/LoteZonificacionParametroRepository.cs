using Jca.Sigmuni.Domain.Zonificaciones;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.Zonificaciones.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.Zonificaciones.Implementations
{
    public class LoteZonificacionParametroRepository : ILoteZonificacionParametroRepository
    {
        private readonly ApplicationDbContext _context;

        public LoteZonificacionParametroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LoteZonificacionParametro?> BuscarClaseYATNPorIdCartograficoLoteAsync(string idCartograficoLote)
         => await _context.LoteZonificacionParametros.Include(e => e.ZonificacionParametro).ThenInclude(e => e.ClaseZonificacion)
                                                     .Include(e => e.ZonificacionParametro).ThenInclude(e => e.AreaTratamiento)
                                                     .Where(e => e.IdLote == idCartograficoLote && e.Estado == true)
                                                     .FirstOrDefaultAsync();

        public async Task<LoteZonificacionParametro> BuscarPorIdLoteCartografiaAsync(string IdLoteCartografia)
          => await _context.LoteZonificacionParametros
              //.Include(x => x.ZonificacionParametro.Ubigeo)
              //.Include(x => x.ZonificacionParametro.ClaseZonificacion)
              //.Include(x => x.ZonificacionParametro.AreaTratamiento)
              //.Include(x => x.ZonificacionParametro.ParametroUrbanistico).ThenInclude(t => t.DetalleParametroUrbanisticos.Where(u => u.Estado == true))
              //.Include(e => e.ZonificacionParametro.ZonificacionParametroNormaInteres.Where(c => c.Estado == true))
              //    .ThenInclude(t => t.NormaInteres).ThenInclude(s => s.NormaDiaDetalle).ThenInclude(p => p.NormaDia).ThenInclude(z => z.TipoNorma)
              //.Include(e => e.ZonificacionParametro.ZonificacionParametroNormaInteres)
              //    .ThenInclude(t => t.NormaInteres).ThenInclude(s => s.Naturaleza)
              //.Include(e => e.ZonificacionParametro.ZonificacionParametroNormaInteres)
              //        .ThenInclude(t => t.NormaInteres).ThenInclude(s => s.ClasificacionNorma)
              //.Include(e => e.ZonificacionParametro.ZonificacionParametroNormaInteres)
              //        .ThenInclude(t => t.NormaInteres).ThenInclude(s => s.Documento)
              .Where(x => x.IdLote == IdLoteCartografia)
              .FirstOrDefaultAsync();

    }
}
