using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class NormaIntMonPrehiRepository : INormaIntMonPrehiRepository
    {
        private readonly ApplicationDbContext _context;

        public NormaIntMonPrehiRepository(ApplicationDbContext context, IPaginator<NormaIntMonPrehi> paginator)
        {
            _context = context;

        }

        public async Task<NormaIntMonPrehi> Create(NormaIntMonPrehi entity)
        {
            _context.NormaIntMonPrehis.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<NormaIntMonPrehi?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<NormaIntMonPrehi?> Edit(int id, NormaIntMonPrehi entity)
        {
            var model = await _context.NormaIntMonPrehis.FindAsync(id);

            if (model != null)
            {
                model.NumPlano = entity.NumPlano;
                model.Fecha = entity.Fecha;
                model.IdMonumentoPre = entity.IdMonumentoPre;
                model.IdNormaInteres = entity.IdNormaInteres;
                


                _context.NormaIntMonPrehis.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public Task<NormaIntMonPrehi?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<NormaIntMonPrehi>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<NormaIntMonPrehi>> ListarPorIdMonumentoPreAsync(int? idMonumentoPre)
       => await _context.NormaIntMonPrehis.Where(e => e.IdNormaIntMonPrehi == idMonumentoPre).ToListAsync();

        public async Task<NormaIntMonPrehi> BuscarPorIdAsync(int id)
        => await _context.NormaIntMonPrehis.Where(e => e.IdNormaIntMonPrehi == id).FirstOrDefaultAsync();

    }
}
