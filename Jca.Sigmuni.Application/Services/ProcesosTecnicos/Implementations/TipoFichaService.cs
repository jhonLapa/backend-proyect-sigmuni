using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoFichas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoFichaService : ITipoFichaService
    {

        private readonly IMapper _mapper;
        private readonly ITipoFichaRepository _tipoFichaRepository;

        public TipoFichaService(IMapper mapper, ITipoFichaRepository tipoFichaRepository)
        {
            _mapper = mapper;
            _tipoFichaRepository = tipoFichaRepository;
        }
        public async Task<IList<TipoFichaDto>> FindAll()
        {
            var response = await _tipoFichaRepository.FindAll();

            return _mapper.Map<IList<TipoFichaDto>>(response);
        }



    }
}
