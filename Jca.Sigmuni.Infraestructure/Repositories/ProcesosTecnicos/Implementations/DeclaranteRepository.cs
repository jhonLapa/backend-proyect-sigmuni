using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class DeclaranteRepository : IDeclaranteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Declarante> _paginator;

        public DeclaranteRepository(ApplicationDbContext context, IPaginator<Declarante> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Declarante> Create(Declarante entity)
        {
            _context.Declarantes.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<Declarante?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Declarante?> Edit(int id, Declarante entity)
        {
            var model = await _context.Declarantes.FindAsync(id);

            if (model != null)
            {
                model.IdPersona = entity.IdPersona;
                model.IdCondicionPer = entity.IdCondicionPer;
                model.IdFicha = entity.IdFicha;
                model.Firma = entity.Firma;
                model.Firma = entity.Firma;
                model.Fecha = entity.Fecha;

                _context.Declarantes.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Declarante?> FindById(int? id)
        => await _context.Declarantes.DefaultIfEmpty()
                                     .FirstOrDefaultAsync(i => i.IdDeclarante.Equals(id));

        public Task<IList<Declarante>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePagination<Declarante>> PaginatedSearch(RequestPagination<Declarante> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var model = await _context.Declarantes.FindAsync(id);

            if (model != null)
            {
                _context.Declarantes.Remove(model); // consultar si es para borrar directo de la bd
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public Task<Declarante?> Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
