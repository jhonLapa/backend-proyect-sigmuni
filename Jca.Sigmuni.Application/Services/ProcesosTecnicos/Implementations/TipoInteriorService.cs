using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInteriores;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoInteriorService : ITipoInteriorService
    {

        private readonly IMapper _mapper;
        private readonly ITipoInteriorRepository _tipoInteriorRepository;

        public TipoInteriorService(IMapper mapper, ITipoInteriorRepository tipoInteriorRepository)
        {
            _mapper = mapper;
            _tipoInteriorRepository = tipoInteriorRepository;
        }
        public async Task<IList<TipoInteriorDto>> FindAll()
        {
            var response = await _tipoInteriorRepository.FindAll();

            return _mapper.Map<IList<TipoInteriorDto>>(response);
        }



    }
}
