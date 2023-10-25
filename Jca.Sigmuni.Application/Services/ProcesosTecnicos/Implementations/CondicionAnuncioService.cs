using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionAnuncios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class CondicionAnuncioService : ICondicionAnuncioService
    {

        private readonly IMapper _mapper;
        private readonly ICondicionAnuncioRepository _condicionAnuncioRepository;

        public CondicionAnuncioService(IMapper mapper, ICondicionAnuncioRepository condicionAnuncioRepository)
        {
            _mapper = mapper;
            _condicionAnuncioRepository = condicionAnuncioRepository;
        }
        public async Task<IList<CondicionAnuncioDto>> FindAll()
        {
            var response = await _condicionAnuncioRepository.FindAll();

            return _mapper.Map<IList<CondicionAnuncioDto>>(response);
        }



    }
}
