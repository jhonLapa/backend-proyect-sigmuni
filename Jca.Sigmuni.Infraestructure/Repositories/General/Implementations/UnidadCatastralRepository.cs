using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class UnidadCatastralRepository : IUnidadCatastralRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<UnidadCatastral> _paginator;

        public UnidadCatastralRepository(ApplicationDbContext context, IPaginator<UnidadCatastral> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<UnidadCatastral> Create(UnidadCatastral entity)
        {
            _context.UnidadesCatastrales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<UnidadCatastral?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UnidadCatastral?> Edit(int id, UnidadCatastral entity)
        {
            var model = await _context.UnidadesCatastrales.FindAsync(id);

            if (model != null)
            {
                model.CodigoCatastral = entity.CodigoCatastral;
                model.CodigoHojaCatastral = entity.CodigoHojaCatastral;
                model.CodigoPredialSat = entity.CodigoPredialSat;
                model.UnidadAcumuladaCodigo = entity.UnidadAcumuladaCodigo;
                model.Correlativo = entity.Correlativo;
                model.IdMotivo = entity.IdMotivo;
                model.IdLoteCarto = entity.IdLoteCarto;
                model.CodigoRefCatastral = entity.CodigoRefCatastral;
                model.Ambito = entity.Ambito;
                model.AnioUltimoDDJJ = entity.AnioUltimoDDJJ;
                model.Cuc = entity.Cuc;

                _context.UnidadesCatastrales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<UnidadCatastral?> Find(int id)
        => await _context.UnidadesCatastrales.Include(e => e.TblCodigo).DefaultIfEmpty()
            .FirstOrDefaultAsync(i => i.IdUnidadCatastral.Equals(id));

        public async Task<IList<UnidadCatastral>> FindAll()
        => await _context.UnidadesCatastrales

           .Where(e => e.Estado == true)
           .ToListAsync();

        public async Task<UnidadCatastral> ObtenerPorCodigoCatastralAsync(TblCodigo peticion)
        {
            UnidadCatastral unidadCatastral = null;

            var response = await _context.TblCodigos
                .Include(e => e.UnidadCatastral).ThenInclude(e => e.Fichas)
                .Where(e =>
                    e.CodDistrito.ToUpper().Trim() == peticion.CodDistrito.ToUpper().Trim()
                    && e.CodSector.ToUpper().Trim() == peticion.CodSector.ToUpper().Trim()
                    && e.CodManzana.ToUpper().Trim() == peticion.CodManzana.ToUpper().Trim()
                    && e.CodLote.ToUpper().Trim() == peticion.CodLote.ToUpper().Trim()
                    && e.CodEdif.ToUpper().Trim() == peticion.CodEdif.ToUpper().Trim()
                    && e.CodEnt.ToUpper().Trim() == peticion.CodEnt.ToUpper().Trim()
                    && e.CodPiso.ToUpper().Trim() == peticion.CodPiso.ToUpper().Trim()
                    && e.CodUnid.ToUpper().Trim() == peticion.CodUnid.ToUpper().Trim()
                    && e.FlagTipo.ToUpper().Trim() == FlagTipoCodigo.CodigoCatastral.ToUpper().Trim())
                .FirstOrDefaultAsync();

            if (response?.UnidadCatastral != null) unidadCatastral = response.UnidadCatastral;

            return unidadCatastral;
        }

        public async Task<List<UnidadCatastral>> ObtenerPorIdLoteCartoAsync(string? idLoteCarto)
        => await _context.UnidadesCatastrales.Where(x => x.IdLoteCarto == idLoteCarto).ToListAsync();

        public async Task<List<UnidadCatastral>> ObtenerPorCodigoCatastralBienComunAsync(TblCodigo peticion)
        {
            List<UnidadCatastral> unidadCatastral = new List<UnidadCatastral>();

            var response = await _context.TblCodigos
                .Include(e => e.UnidadCatastral).ThenInclude(e => e.Fichas)
                .Where(e =>
                    e.CodDistrito.ToUpper().Trim() == peticion.CodDistrito.ToUpper().Trim()
                    && e.CodSector.ToUpper().Trim() == peticion.CodSector.ToUpper().Trim()
                    && e.CodManzana.ToUpper().Trim() == peticion.CodManzana.ToUpper().Trim()
                    && e.CodLote.ToUpper().Trim() == peticion.CodLote.ToUpper().Trim()
                    && (string.IsNullOrWhiteSpace(peticion.CodEdif) || e.CodEdif.ToUpper().Trim() == peticion.CodEdif.ToUpper().Trim())
                    && (string.IsNullOrWhiteSpace(peticion.CodEnt) || e.CodEnt.ToUpper().Trim() == peticion.CodEnt.ToUpper().Trim())
                    && (string.IsNullOrWhiteSpace(peticion.CodPiso) || e.CodPiso.ToUpper().Trim() == peticion.CodPiso.ToUpper().Trim())
                    && (string.IsNullOrWhiteSpace(peticion.CodUnid) || e.CodUnid.ToUpper().Trim() == peticion.CodUnid.ToUpper().Trim())
                    && e.FlagTipo.ToUpper().Trim() == FlagTipoCodigo.CodigoCatastral.ToUpper().Trim())

                .ToListAsync();

            response.ForEach(tc =>
            {
                if (tc.UnidadCatastral != null)
                {
                    unidadCatastral.Add(tc.UnidadCatastral);
                }
            });


            return unidadCatastral;
        }

        public async Task<UnidadCatastral?> MaximoCUCAsync(string lote)
        => await _context.UnidadesCatastrales.Where(e => e.IdLoteCarto == lote).OrderByDescending(e => e.CodigoCatastral).FirstOrDefaultAsync();
    }
}
