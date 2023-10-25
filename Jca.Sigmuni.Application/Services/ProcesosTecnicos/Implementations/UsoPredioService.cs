using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UsosPredios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class UsoPredioService : IUsoPredioService
    {

        private readonly IMapper _mapper;
        private readonly IUsoPredioRepository _usoPredioRepository;

        public UsoPredioService(IMapper mapper, IUsoPredioRepository usoPredioRepository)
        {
            _mapper = mapper;
            _usoPredioRepository = usoPredioRepository;
        }
        public async Task<IList<UsoPredioDto>> FindAll()
        {
            var response = await _usoPredioRepository.FindAll();

            return _mapper.Map<IList<UsoPredioDto>>(response);
        }



    }
}
