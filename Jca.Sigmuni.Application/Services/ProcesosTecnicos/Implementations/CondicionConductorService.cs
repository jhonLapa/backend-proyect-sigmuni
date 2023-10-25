using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionConductores;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class CondicionConductorService : ICondicionConductorService
    {

        private readonly IMapper _mapper;
        private readonly ICondicionConductorRepository _condicionConductorRepository;

        public CondicionConductorService(IMapper mapper, ICondicionConductorRepository condicionConductorRepository)
        {
            _mapper = mapper;
            _condicionConductorRepository = condicionConductorRepository;
        }
        public async Task<IList<CondicionConductorDto>> FindAll()
        {
            var response = await _condicionConductorRepository.FindAll();

            return _mapper.Map<IList<CondicionConductorDto>>(response);
        }



    }
}
