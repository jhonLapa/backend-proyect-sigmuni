using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class TblCodigoRepository : ITblCodigoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TblCodigo> _paginator;

        public TblCodigoRepository(ApplicationDbContext context, IPaginator<TblCodigo> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<TblCodigo> Create(TblCodigo entity)
        {
            _context.TblCodigos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TblCodigo?> Edit(int id, TblCodigo entity)
        {
            var model = await _context.TblCodigos.FindAsync(id);

            if (model != null)
            {
                model.CodDepartamento = entity.CodDepartamento;
                model.CodProvincia = entity.CodProvincia;
                model.CodDistrito = entity.CodDistrito;
                model.CodSector = entity.CodSector;
                model.CodManzana = entity.CodManzana;
                model.CodLote = entity.CodLote;
                model.CodEdif = entity.CodEdif;
                model.CodEnt = entity.CodEnt;
                model.CodPiso = entity.CodPiso;
                model.CodUnid = entity.CodUnid;
                model.DigitoControl = entity.DigitoControl;
                model.FlagTipo = entity.FlagTipo;
                model.IdUnidadCatastral = entity.IdUnidadCatastral;

                _context.TblCodigos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

       

        public async Task<TblCodigo?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TblCodigo?> Find(int id)
        => await _context.TblCodigos.DefaultIfEmpty()
                                    .FirstOrDefaultAsync(i => i.IdTblCodigo.Equals(id));

        //FindAsync(id);

        public async Task<IList<TblCodigo>> FindAll()
        => await _context.TblCodigos

           .Where(e => e.Estado == true)
           .ToListAsync();

        public async Task<ResponsePagination<TblCodigo>> PaginatedSearch(RequestPagination<TblCodigo> entity)
        {

            throw new NotImplementedException();

        }

        public async Task<TblCodigo?> BuscarPorIdUnidadCatastralAsync(int id)
        => await _context.TblCodigos.Where(e => e.IdUnidadCatastral == id && e.FlagTipo == FlagTipoCodigo.CodigoCatastral)
            .FirstOrDefaultAsync();
    }
}
