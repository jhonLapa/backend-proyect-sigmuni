using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesTitulares;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class CondicionTitularService : ICondicionTitularService
    {

        private readonly IMapper _mapper;
        private readonly ICondicionTitularRepository _condicionTitularRepository;

        public CondicionTitularService(IMapper mapper, ICondicionTitularRepository condicionTitularRepository)
        {
            _mapper = mapper;
            _condicionTitularRepository = condicionTitularRepository;
        }
        public async Task<IList<CondicionTitularDto>> FindAll()
        {
            var response = await _condicionTitularRepository.FindAll();

            return _mapper.Map<IList<CondicionTitularDto>>(response);
        }



    }
}
