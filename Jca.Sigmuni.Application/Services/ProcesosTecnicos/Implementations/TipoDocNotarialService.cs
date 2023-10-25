using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocNotariales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoDocNotarialService : ITipoDocNotarialService
    {

        private readonly IMapper _mapper;
        private readonly ITipoDocNotarialRepository _tipoDocNotarialRepository;

        public TipoDocNotarialService(IMapper mapper, ITipoDocNotarialRepository tipoDocNotarialRepository)
        {
            _mapper = mapper;
            _tipoDocNotarialRepository = tipoDocNotarialRepository;
        }
        public async Task<IList<TipoDocNotarialDto>> FindAll()
        {
            var response = await _tipoDocNotarialRepository.FindAll();

            return _mapper.Map<IList<TipoDocNotarialDto>>(response);
        }



    }
}
