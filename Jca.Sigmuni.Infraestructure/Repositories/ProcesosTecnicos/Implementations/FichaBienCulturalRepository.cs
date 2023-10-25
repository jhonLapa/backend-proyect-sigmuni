using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class FichaBienCulturalRepository :IFichaBienCulturalRepository
    {
        private readonly ApplicationDbContext _context;

        public FichaBienCulturalRepository(ApplicationDbContext context, IPaginator<FichaBienCultural> paginator)
        {
            _context = context;
            
        }

        public async Task<FichaBienCultural> Create(FichaBienCultural entity)
        {
            _context.FichasBienesCulturales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<FichaBienCultural?> Edit(int id, FichaBienCultural entity)
        {
            var model = await _context.FichasBienesCulturales.FindAsync(id);

            if (model != null)
            {
                model.CUIDistrito = entity.CUIDistrito;
                model.CUISector = entity.CUISector;
                model.CUIManzana = entity.CUIManzana;
                model.CUILote = entity.CUILote;
                model.CUISubLote = entity.CUISubLote;
                model.CRCZona = entity.CRCZona;
                model.CRCCoordenadaEsta = entity.CRCCoordenadaEsta;
                model.CRCCoordenadaNorte = entity.CRCCoordenadaNorte;
                model.CRCUnidadCatastral = entity.CRCUnidadCatastral;
                model.IdFicha = entity.IdFicha;
                

                _context.FichasBienesCulturales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<FichaBienCultural> BuscarPorIdAsync(int id)
        => await _context.FichasBienesCulturales.Where(e => e.IdFichaBienCultural == id).FirstOrDefaultAsync();

        public Task<FichaBienCultural?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<FichaBienCultural>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<FichaBienCultural?> Disable(int id)
        {
            throw new NotImplementedException();
        }
    }
}
