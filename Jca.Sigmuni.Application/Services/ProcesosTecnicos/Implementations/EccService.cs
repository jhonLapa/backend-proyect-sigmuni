using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Eccs;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class EccService : IEccService
    {

        private readonly IMapper _mapper;
        private readonly IEccRepository _eccRepository;

        public EccService(IMapper mapper, IEccRepository eccRepository)
        {
            _mapper = mapper;
            _eccRepository = eccRepository;
        }
        public async Task<IList<EccDto>> FindAll()
        {
            var response = await _eccRepository.FindAll();

            return _mapper.Map<IList<EccDto>>(response);
        }



    }
}
