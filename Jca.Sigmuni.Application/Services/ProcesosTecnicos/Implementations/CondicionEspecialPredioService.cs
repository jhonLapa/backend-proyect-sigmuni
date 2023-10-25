using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesEspecialesPredios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class CondicionEspecialPredioService : ICondicionEspecialPredioService
    {

        private readonly IMapper _mapper;
        private readonly ICondicionEspecialPredioRepository _condicionEspecialPredioRepository;

        public CondicionEspecialPredioService(IMapper mapper, ICondicionEspecialPredioRepository condicionEspecialPredioRepository)
        {
            _mapper = mapper;
            _condicionEspecialPredioRepository = condicionEspecialPredioRepository;
        }
        public async Task<IList<CondicionEspecialPredioDto>> FindAll()
        {
            var response = await _condicionEspecialPredioRepository.FindAll();

            return _mapper.Map<IList<CondicionEspecialPredioDto>>(response);
        }



    }
}
