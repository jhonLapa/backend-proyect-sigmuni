using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Vias.TipoVias;
using Jca.Sigmuni.Application.Services.Vias.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Vias.Abstractions;

namespace Jca.Sigmuni.Application.Services.Vias.Implementations
{
    public class TipoViaService : ITipoViaService
    {

        private readonly IMapper _mapper;
        private readonly ITipoViaRepository _tipoViaRepository;

        public TipoViaService(IMapper mapper, ITipoViaRepository tipoViaRepository)
        {
            _mapper = mapper;
            _tipoViaRepository = tipoViaRepository;
        }
        public async Task<IList<TipoViaDto>> FindAll()
        {
            var response = await _tipoViaRepository.FindAll();

            return _mapper.Map<IList<TipoViaDto>>(response);
        }



    }
}
