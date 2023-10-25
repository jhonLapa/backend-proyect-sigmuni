using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Monedas;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class MonedaService : IMonedaService
    {

        private readonly IMapper _mapper;
        private readonly IMonedaRepository _MonedaRepository;

        public MonedaService(IMapper mapper, IMonedaRepository MonedaRepository)
        {
            _mapper = mapper;
            _MonedaRepository = MonedaRepository;
        }
        public async Task<IList<MonedaDto>> FindAll()
        {
            var response = await _MonedaRepository.FindAll();

            return _mapper.Map<IList<MonedaDto>>(response);
        }



    }
}
