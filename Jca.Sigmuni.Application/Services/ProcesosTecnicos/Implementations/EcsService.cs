using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class EcsService : IEcsService
    {

        private readonly IMapper _mapper;
        private readonly IEcsRepository _ecsRepository;

        public EcsService(IMapper mapper, IEcsRepository ecsRepository)
        {
            _mapper = mapper;
            _ecsRepository = ecsRepository;
        }
        public async Task<IList<EcsDto>> FindAll()
        {
            var response = await _ecsRepository.FindAll();

            return _mapper.Map<IList<EcsDto>>(response);
        }



    }
}
