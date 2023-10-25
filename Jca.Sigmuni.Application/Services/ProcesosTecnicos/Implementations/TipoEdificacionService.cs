using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoEdificaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoEdificacionService : ITipoEdificacionService
    {

        private readonly IMapper _mapper;
        private readonly ITipoEdificacionRepository _tipoEdificacionRepository;

        public TipoEdificacionService(IMapper mapper, ITipoEdificacionRepository tipoEdificacionRepository)
        {
            _mapper = mapper;
            _tipoEdificacionRepository = tipoEdificacionRepository;
        }
        public async Task<IList<TipoEdificacionDto>> FindAll()
        {
            var response = await _tipoEdificacionRepository.FindAll();

            return _mapper.Map<IList<TipoEdificacionDto>>(response);
        }



    }
}
