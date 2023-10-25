using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredios;
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
    public class EvaluacionPredioService : IEvaluacionPredioService
    {
        private readonly IMapper _mapper;
        private readonly IEvaluacionPredioRepository _evaluacionPredioRepository;

        public EvaluacionPredioService(IMapper mapper,
                                       IEvaluacionPredioRepository evaluacionPredioRepository)
        {
            _mapper = mapper;
            _evaluacionPredioRepository = evaluacionPredioRepository;
        }

        public async Task<EvaluacionPredio?> CrearOActualizarAsync(EvaluacionPredioDto peticion)
        {
            var id = peticion.IdEvaluacionPredio;

            var evaluacionPredio = await _evaluacionPredioRepository.Find(id);

            if (evaluacionPredio == null)
            {
                evaluacionPredio = new EvaluacionPredio();
            }

            //if (peticion.TipoEvaluacion == null)   ===========>>> consultar el retornar tipo de error
            //{
            //    return new OperacionDto<RespuestaSimpleDto<long>>(CodigosOperacionDto.Invalido, "El el Id de tipo evaluación predio es requerido");
            //}

            var idTipoEvaluacion = new int();
            if (peticion.TipoEvaluacion != null)
            {
                idTipoEvaluacion = peticion.TipoEvaluacion.IdTipoEvaluacion != 0 ? peticion.TipoEvaluacion.IdTipoEvaluacion : new int();
            }


            evaluacionPredio.Area = peticion.Area;
            evaluacionPredio.IdTipoEvaluacion = idTipoEvaluacion;
            evaluacionPredio.IdFicha = peticion.IdFicha;

            if (evaluacionPredio.IdEvaluacionPredio == 0)
            {
                return await _evaluacionPredioRepository.Create(evaluacionPredio);
            }
            else
            {
                return await _evaluacionPredioRepository.Edit(evaluacionPredio.IdEvaluacionPredio, evaluacionPredio);
            }
        }
    }
}
