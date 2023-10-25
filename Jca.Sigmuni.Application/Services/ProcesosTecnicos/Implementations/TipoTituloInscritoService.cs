using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoTituloInscritos;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoTituloInscritoService : ITipoTituloInscritoService
    {

        private readonly IMapper _mapper;
        private readonly ITipoTituloInscritoRepository _tipoTituloInscritoRepository;

        public TipoTituloInscritoService(IMapper mapper, ITipoTituloInscritoRepository tipoTituloInscritoRepository)
        {
            _mapper = mapper;
            _tipoTituloInscritoRepository = tipoTituloInscritoRepository;
        }
        public async Task<IList<TipoTituloInscritoDto>> FindAll()
        {
            var response = await _tipoTituloInscritoRepository.FindAll();

            return _mapper.Map<IList<TipoTituloInscritoDto>>(response);
        }



    }
}
