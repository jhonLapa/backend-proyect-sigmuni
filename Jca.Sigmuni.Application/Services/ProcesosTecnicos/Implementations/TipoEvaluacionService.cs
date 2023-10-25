using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoEvaluaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoEvaluacionService : ITipoEvaluacionService
    {

        private readonly IMapper _mapper;
        private readonly ITipoEvaluacionRepository _tipoEvaluacionRepository;

        public TipoEvaluacionService(IMapper mapper, ITipoEvaluacionRepository tipoEvaluacionRepository)
        {
            _mapper = mapper;
            _tipoEvaluacionRepository = tipoEvaluacionRepository;
        }
        public async Task<IList<TipoEvaluacionDto>> FindAll()
        {
            var response = await _tipoEvaluacionRepository.FindAll();

            return _mapper.Map<IList<TipoEvaluacionDto>>(response);
        }



    }
}
