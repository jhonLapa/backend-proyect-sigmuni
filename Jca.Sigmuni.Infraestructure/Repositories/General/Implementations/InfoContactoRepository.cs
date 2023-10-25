using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class InfoContactoRepository : IInfoContactoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<InfoContacto> _paginator;

        public InfoContactoRepository(ApplicationDbContext context, IPaginator<InfoContacto> paginator)
        { 
            _context = context;
            _paginator = paginator;
        }
        public async Task<InfoContacto> Create(InfoContacto entity)
        {
            _context.InfoContactos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<InfoContacto?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<InfoContacto?> Edit(int id, InfoContacto entity)
        {
            var model = await _context.InfoContactos.FindAsync(id);

            if (model != null)
            {
                model.Telefono = entity.Telefono;
                model.Correo = entity.Correo;
                model.Anexo = entity.Anexo;
                model.Fax = entity.Fax;
                model.Telefono = entity.Telefono;

                _context.InfoContactos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<InfoContacto?> Find(int id)
         => await _context.InfoContactos.FindAsync(id);

        public async Task<IList<InfoContacto>> FindAll()
        => await _context.InfoContactos.OrderByDescending(e => e.Id).ToListAsync();
            //.OrderByDescending(e => e.Id)
            //.ToListAsync();

        public async Task<ResponsePagination<InfoContacto>> PaginatedSearch(RequestPagination<InfoContacto> entity)
        {
            var filter = entity.Filter;
            var query = _context.InfoContactos.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (string.IsNullOrWhiteSpace(filter.Telefono) || e.Telefono == filter.Telefono)
                    && (string.IsNullOrWhiteSpace(filter.Correo) || e.Correo.ToUpper().Contains(filter.Correo.ToUpper().Trim()))
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;
        }
    }
}
