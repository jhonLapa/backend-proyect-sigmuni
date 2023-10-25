using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class CondicionPerService : ICondicionPerService
    {
        private readonly IMapper _mapper;
        private readonly ICondicionPerRepository _condicionPerRepository;

        public CondicionPerService(IMapper mapper, ICondicionPerRepository condicionPerRepository)
        {
            _mapper = mapper;
            _condicionPerRepository = condicionPerRepository;
        }
        public async Task<IList<CondicionPerDto>> FindAll()
        {
            var response = await _condicionPerRepository.FindAll();

            return _mapper.Map<IList<CondicionPerDto>>(response);
        }
    }
}
