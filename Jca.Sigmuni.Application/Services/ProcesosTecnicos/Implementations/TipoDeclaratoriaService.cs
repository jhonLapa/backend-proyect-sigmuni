using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDeclaratorias;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoDeclaratoriaService : ITipoDeclaratoriaService
    {

        private readonly IMapper _mapper;
        private readonly ITipoDeclaratoriaRepository _tipoDeclaratoriaRepository;

        public TipoDeclaratoriaService(IMapper mapper, ITipoDeclaratoriaRepository tipoDeclaratoriaRepository)
        {
            _mapper = mapper;
            _tipoDeclaratoriaRepository = tipoDeclaratoriaRepository;
        }
        public async Task<IList<TipoDeclaratoriaDto>> FindAll()
        {
            var response = await _tipoDeclaratoriaRepository.FindAll();

            return _mapper.Map<IList<TipoDeclaratoriaDto>>(response);
        }



    }
}
