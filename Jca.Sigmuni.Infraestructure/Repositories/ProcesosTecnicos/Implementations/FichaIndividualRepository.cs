using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations
{
    public class FichaIndividualRepository : IFichaIndividualRepository
    {
        private readonly ApplicationDbContext _context;

        public FichaIndividualRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FichaIndividual> Create(FichaIndividual entity)
        {
            _context.FichaIndividuales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<FichaIndividual?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FichaIndividual?> Edit(int id, FichaIndividual entity)
        {
            var model = await _context.FichaIndividuales.FindAsync(id);

            if (model != null)
            {
                model.CodContRentas = entity.CodContRentas;
                model.CodPredRentas = entity.CodPredRentas;
                model.UnidadPredRentas = entity.UnidadPredRentas;
                model.IdFicha = entity.IdFicha;
                model.AreaTechadaLegal = entity.AreaTechadaLegal;
                model.AreaOcupadaLegal = entity.AreaOcupadaLegal;
                model.AreaOcupadaVerif = entity.AreaOcupadaVerif;
                model.PorcBcGenLegal = entity.PorcBcGenLegal;
                model.PorcBcLegalTerr = entity.PorcBcLegalTerr;
                model.PorcBcLegalConst = entity.PorcBcLegalConst;
                model.PorcBcFiscTerr = entity.PorcBcFiscTerr;
                model.PorcBcFiscConst = entity.PorcBcFiscConst;
                model.IdPredioCatastralAn = entity.IdPredioCatastralAn;
                model.AreaHabActEcon = entity.AreaHabActEcon;
                model.IdTipoDeclaratoria = entity.IdTipoDeclaratoria;

                _context.FichaIndividuales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<FichaIndividual?> Find(int id)
        => await _context.FichaIndividuales.Include(e => e.PredioCatastralAn)
                                           .FirstOrDefaultAsync(i => i.IdFichaIndividual.Equals(id));

        public Task<IList<FichaIndividual>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
