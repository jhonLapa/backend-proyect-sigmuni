using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.CompendioNormas.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.CompendioNormas.Implementations
{
    public class NormaDiaDetalleRepository : INormaDiaDetalleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<NormaDiaDetalle> _paginator;

        public NormaDiaDetalleRepository(ApplicationDbContext context, IPaginator<NormaDiaDetalle> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<NormaDiaDetalle> Create(NormaDiaDetalle entity)
        {
            _context.NormaDiaDetalles.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<NormaDiaDetalle?> Disable(int id)
        {
            var model = await _context.NormaDiaDetalles.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.NormaDiaDetalles.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<NormaDiaDetalle?> Edit(int id, NormaDiaDetalle entity)
        {
            var model = await _context.NormaDiaDetalles.FindAsync(id);

            if (model != null)
            {
                model.Nombre = entity.Nombre;
                model.Sumilla = entity.Sumilla;
                model.Enlace = entity.Enlace;
                model.Estado = entity.Estado;

                _context.NormaDiaDetalles.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<NormaDiaDetalle?> Find(int id)
       => await _context.NormaDiaDetalles.FindAsync(id);

        public async Task<IList<NormaDiaDetalle>> FindAll()
       => await _context.NormaDiaDetalles
           .Where(e => e.Estado == true)
           .OrderByDescending(e => e.IdNormaDiaDetalle)
           .ToListAsync();


        public async Task<ResponsePagination<NormaDiaDetalle>> PaginatedSearch(RequestPagination<NormaDiaDetalle> entity)
        {
            throw new NotImplementedException();
        }
    }
}
