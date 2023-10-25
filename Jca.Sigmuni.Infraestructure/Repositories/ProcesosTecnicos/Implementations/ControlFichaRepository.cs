using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abastractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class ControlFichaRepository : IControlFichaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<ControlFicha> _paginator;

        public ControlFichaRepository(ApplicationDbContext context, IPaginator<ControlFicha> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<ControlFicha> Create(ControlFicha entity)
        {
            _context.ControlFichas.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<ControlFicha?> Edit(int id, ControlFicha entity)
        {
            var model = await _context.ControlFichas.FindAsync(id);

            if (model != null)
            {
                model.EsConforme = entity.EsConforme;
                model.FechaActualizacion = entity.FechaActualizacion;
                model.Observacion = entity.Observacion;

                _context.ControlFichas.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<ControlFicha?> Disable(int id)
        {
            var model = await _context.ControlFichas.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.ControlFichas.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<ControlFicha?> Find(int id)
        => await _context.ControlFichas.FindAsync(id);

        public async Task<IList<ControlFicha>> FindAll()
        => await _context.ControlFichas
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public Task<ResponsePagination<ControlFicha>> PaginatedSearch(RequestPagination<ControlFicha> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ControlFicha?> BuscarPorControlFicha(ControlFicha controlFicha)
        => await _context.ControlFichas.Where(e =>
            e.IdFicha == controlFicha.IdFicha
            && e.NombreTab.ToUpper().Trim() == controlFicha.NombreTab.ToUpper().Trim()
            && e.NombreCampo.ToUpper().Trim() == controlFicha.NombreCampo.ToUpper().Trim()
        ).FirstOrDefaultAsync();

        public async Task<List<ControlFicha>> BuscarPorIdUnidadCatastralAsync(int idUnidadCatastral)
        => await _context.ControlFichas.Where(x => x.IdUnidadCatastral == idUnidadCatastral).ToListAsync();

        public async Task<List<ControlFicha>> BuscarPorIdFichaAsync(int idFicha)
        => await _context.ControlFichas.Where(x => x.IdFicha == idFicha).ToListAsync();
    }
}
