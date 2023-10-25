using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredioCatastrales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class EvaluacionPredioCatastralService : IEvaluacionPredioCatastralService
    {
        private readonly IMapper _mapper;
        private readonly IEvaluacionPredioCatastralRepository _evaluacionPredioCatastralRepository;

        public EvaluacionPredioCatastralService(IMapper mapper, 
                                                IEvaluacionPredioCatastralRepository evaluacionPredioCatastralRepository)
        {
            _mapper = mapper;
            _evaluacionPredioCatastralRepository = evaluacionPredioCatastralRepository;
        }

        public async Task<EvaluacionPredioCatastral?> CrearOActualizarAsync(EvaluacionPredioCatastralDto peticion)
        {
            var evaluacionPredioCatastral = await _evaluacionPredioCatastralRepository.Find(peticion.Id ?? 0);

            if (evaluacionPredioCatastral == null)
            {
                evaluacionPredioCatastral = new EvaluacionPredioCatastral();
            }

            evaluacionPredioCatastral.PredioCatastralOmiso = peticion.PredioCatastralOmiso;
            evaluacionPredioCatastral.PredioCatastralSubEvaluado = peticion.PredioCatastralSubEvaluado;
            evaluacionPredioCatastral.PredioCatastralSobreEvaluado = peticion.PredioCatastralSobreEvaluado;
            evaluacionPredioCatastral.PredioCatastralConforme = peticion.PredioCatastralConforme;
            evaluacionPredioCatastral.IdFicha = peticion.IdFicha;

            if (evaluacionPredioCatastral.Id == 0)
            {
                return await _evaluacionPredioCatastralRepository.Create(evaluacionPredioCatastral);
            }
            else
            {
                return await _evaluacionPredioCatastralRepository.Edit(evaluacionPredioCatastral.Id, evaluacionPredioCatastral);
            }
        }
    }
}
