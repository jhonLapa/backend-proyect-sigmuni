using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaIndividuales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class FichaIndividualService : IFichaIndividualService
    {
        private readonly IMapper _mapper;
        private readonly IFichaIndividualRepository _fichaIndividualRepository;

        public FichaIndividualService(IMapper mapper,
                                      IFichaIndividualRepository fichaIndividualRepository)
        {
            _mapper = mapper;
            _fichaIndividualRepository = fichaIndividualRepository;
        }

        public async Task<FichaIndividual?> CrearOActualizarAsync(FichaIndividualDto peticion)
        {
            var id = peticion.IdFichaIndividual;

            var fichaIndividual = await _fichaIndividualRepository.Find(id);

            if (fichaIndividual == null)
            {
                fichaIndividual = new FichaIndividual();
            }

            var idPredioCatastralAn = new int?();
            if (peticion.PredioCatastralAn != null)
            {
                idPredioCatastralAn = peticion.PredioCatastralAn.IdPredioCatastralAn != 0 ? peticion.PredioCatastralAn.IdPredioCatastralAn : new int?();
            }

            var idTipoDeclaratoria = default(int?);
            if (peticion.TipoDeclaratoria != null)
            {
                idTipoDeclaratoria = peticion.TipoDeclaratoria.Id != 0 ? peticion.TipoDeclaratoria.Id : new int?();
            }

            fichaIndividual.CodContRentas = peticion.CodContRentas;
            fichaIndividual.CodPredRentas = peticion.CodPredRentas;
            fichaIndividual.UnidadPredRentas = peticion.UnidadPredRentas;
            fichaIndividual.IdFicha = peticion.IdFicha;
            fichaIndividual.AreaTechadaLegal = peticion.AreaTechadaLegal;
            fichaIndividual.AreaOcupadaLegal = peticion.AreaOcupadaLegal;
            fichaIndividual.AreaOcupadaVerif = peticion.AreaOcupadaVerif;
            fichaIndividual.PorcBcGenLegal = peticion.PorcBcGenLegal;
            fichaIndividual.PorcBcLegalTerr = peticion.PorcBcLegalTerr;
            fichaIndividual.PorcBcLegalConst = peticion.PorcBcLegalConst;
            fichaIndividual.PorcBcFiscTerr = peticion.PorcBcFiscTerr;
            fichaIndividual.PorcBcFiscConst = peticion.PorcBcFiscConst;
            fichaIndividual.IdPredioCatastralAn = idPredioCatastralAn;
            fichaIndividual.AreaHabActEcon = peticion.AreaHabActEcon;
            fichaIndividual.IdTipoDeclaratoria = idTipoDeclaratoria;

            if (fichaIndividual.IdFichaIndividual == 0)
            {
                return await _fichaIndividualRepository.Create(fichaIndividual);
            }
            else
            {
                return await _fichaIndividualRepository.Edit(fichaIndividual.IdFichaIndividual, fichaIndividual);
            }
        }
    }
}
