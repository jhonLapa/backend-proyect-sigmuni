using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Meps;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class MepService : IMepService
    {

        private readonly IMapper _mapper;
        private readonly IMepRepository _mepRepository;

        public MepService(IMapper mapper, IMepRepository mepRepository)
        {
            _mapper = mapper;
            _mepRepository = mepRepository;
        }
        public async Task<IList<MepDto>> FindAll()
        {
            var response = await _mepRepository.FindAll();

            return _mapper.Map<IList<MepDto>>(response);
        }



    }
}
