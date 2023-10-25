using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionesPredios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class ClasificacionPredioService : IClasificacionPredioService
    {

        private readonly IMapper _mapper;
        private readonly IClasificacionPredioRepository _clasificacionPredioRepository;

        public ClasificacionPredioService(IMapper mapper, IClasificacionPredioRepository clasificacionPredioRepository)
        {
            _mapper = mapper;
            _clasificacionPredioRepository = clasificacionPredioRepository;
        }
        public async Task<IList<ClasificacionPredioDto>> FindAll()
        {
            var response = await _clasificacionPredioRepository.FindAll();

            return _mapper.Map<IList<ClasificacionPredioDto>>(response);
        }



    }
}
