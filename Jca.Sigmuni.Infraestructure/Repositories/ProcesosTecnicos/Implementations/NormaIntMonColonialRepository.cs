using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class NormaIntMonColonialRepository: INormaIntMonColonialRepository
    {
        private readonly ApplicationDbContext _context;

        public NormaIntMonColonialRepository(ApplicationDbContext context, IPaginator<NormaIntMonColonial> paginator)
        {
            _context = context;

        }
        public async Task<NormaIntMonColonial> BuscarPorIdAsync(int id)
        => await _context.NormaIntMonColoniales.Where(e => e.IdNormaIntMonColonial == id).FirstOrDefaultAsync();


        public async Task<List<NormaIntMonColonial>> ListarPorIdMonumentoColonialAsync(int idMonumentoColonial)
        => await _context.NormaIntMonColoniales.Where(e => e.IdMonumentoColonial == idMonumentoColonial).ToListAsync();

        public async Task<NormaIntMonColonial> Create(NormaIntMonColonial entity)
        {
            _context.NormaIntMonColoniales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<NormaIntMonColonial?> Edit(int id, NormaIntMonColonial entity)
        {
            var model = await _context.NormaIntMonColoniales.FindAsync(id);

            if (model != null)
            {
                model.NumPlano = entity.NumPlano;
                model.Fecha = entity.Fecha;
                model.IdMonumentoColonial = entity.IdMonumentoColonial;
                model.IdNormaInteres = entity.IdNormaInteres;
                


                _context.NormaIntMonColoniales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public Task<NormaIntMonColonial?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<NormaIntMonColonial>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<NormaIntMonColonial?> Disable(int id)
        {
            throw new NotImplementedException();
        }
    }
}
