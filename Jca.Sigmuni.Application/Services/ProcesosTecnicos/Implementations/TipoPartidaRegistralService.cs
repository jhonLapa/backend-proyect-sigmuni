using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPartidaRegistrales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoPartidaRegistralService : ITipoPartidaRegistralService
    {

        private readonly IMapper _mapper;
        private readonly ITipoPartidaRegistralRepository _tipoPartidaRegistralRepository;

        public TipoPartidaRegistralService(IMapper mapper, ITipoPartidaRegistralRepository tipoPartidaRegistralRepository)
        {
            _mapper = mapper;
            _tipoPartidaRegistralRepository = tipoPartidaRegistralRepository;
        }
        public async Task<IList<TipoPartidaRegistralDto>> FindAll()
        {
            var response = await _tipoPartidaRegistralRepository.FindAll();

            return _mapper.Map<IList<TipoPartidaRegistralDto>>(response);
        }



    }
}
