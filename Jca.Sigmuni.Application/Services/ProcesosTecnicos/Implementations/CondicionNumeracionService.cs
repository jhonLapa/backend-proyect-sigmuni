using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesNumeraciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class CondicionNumeracionService : ICondicionNumeracionService
    {
        private readonly IMapper _mapper;
        private readonly ICondicionNumeracionRepository _condicionNumeracionRepository;

        public CondicionNumeracionService(IMapper mapper, ICondicionNumeracionRepository condicionNumeracionRepository)
        {
            _mapper = mapper;
            _condicionNumeracionRepository = condicionNumeracionRepository;
        }
        public async Task<IList<CondicionNumeracionDto>> FindAll()
        {
            var response = await _condicionNumeracionRepository.FindAll();

            return _mapper.Map<IList<CondicionNumeracionDto>>(response);
        }
    }
}
