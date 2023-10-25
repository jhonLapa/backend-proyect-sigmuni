using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoAnuncios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoAnuncioService : ITipoAnuncioService
    {

        private readonly IMapper _mapper;
        private readonly ITipoAnuncioRepository _tipoAnuncioRepository;

        public TipoAnuncioService(IMapper mapper, ITipoAnuncioRepository tipoAnuncioRepository)
        {
            _mapper = mapper;
            _tipoAnuncioRepository = tipoAnuncioRepository;
        }
        public async Task<IList<TipoAnuncioDto>> FindAll()
        {
            var response = await _tipoAnuncioRepository.FindAll();

            return _mapper.Map<IList<TipoAnuncioDto>>(response);
        }



    }
}
