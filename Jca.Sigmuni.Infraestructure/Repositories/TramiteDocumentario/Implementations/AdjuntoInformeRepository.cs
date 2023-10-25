using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class AdjuntoInformeRepository : IAdjuntoInformeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<AdjuntoInforme> _paginator;

        public AdjuntoInformeRepository(ApplicationDbContext context, IPaginator<AdjuntoInforme> paginator)
        {
            _context = context;
            _paginator = paginator;
        }


        public  async Task<AdjuntoInforme> BuscarPorIdYNoBorradoAsync(int id)
          => await _context.AdjuntoInformes.Where(e => e.Id == id && e.Estado == true)
              .FirstOrDefaultAsync();

        public  async Task<AdjuntoInforme> BuscarPorIdAsync(int id)
            => await _context.AdjuntoInformes.Where(e => e.Id == id).FirstOrDefaultAsync();

        public async Task<AdjuntoInforme> BuscarInformeDocumento(int idInforme, int flag)
            => await _context.AdjuntoInformes.Where(x => x.IdInformeTecnico == idInforme && x.Flag == flag && x.Estado == true)
                .FirstOrDefaultAsync();


        public async Task<AdjuntoInforme> BuscarInformeDocumentoDescripcion(int idInforme, int flag, string descripcion)
          => await _context.AdjuntoInformes.Where(x => x.IdInformeTecnico == idInforme && x.Flag == flag && x.Descripcion == descripcion && x.Estado == true)
              .FirstOrDefaultAsync();

        public async Task<AdjuntoInforme> BuscarInformeDocumentoDescripcionFalse(int idInforme, int flag, string descripcion)
       => await _context.AdjuntoInformes.Where(x => x.IdInformeTecnico == idInforme && x.Flag == flag && x.Descripcion == descripcion)
           .FirstOrDefaultAsync();

        public async Task<AdjuntoInforme> Create(AdjuntoInforme entity)
        {
            _context.AdjuntoInformes.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<AdjuntoInforme?> Edit(int id, AdjuntoInforme entity)
        {
            var model = await _context.AdjuntoInformes.FindAsync(id);

            _context.AdjuntoInformes.Update(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<AdjuntoInforme?> Disable(int id)
        {
            var model = await _context.AdjuntoInformes.FindAsync(id);

            if (model != null)
            {

                model.Estado = false;

                _context.AdjuntoInformes.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }



    }
}
