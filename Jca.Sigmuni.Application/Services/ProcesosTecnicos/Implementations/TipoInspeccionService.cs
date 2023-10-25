using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInspecciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoInspeccionService : ITipoInspeccionService
    {

        private readonly IMapper _mapper;
        private readonly ITipoInspeccionRepository _tipoInspeccionRepository;

        public TipoInspeccionService(IMapper mapper, ITipoInspeccionRepository tipoInspeccionRepository)
        {
            _mapper = mapper;
            _tipoInspeccionRepository = tipoInspeccionRepository;
        }
        public async Task<IList<TipoInspeccionDto>> FindAll()
        {
            var response = await _tipoInspeccionRepository.FindAll();

            return _mapper.Map<IList<TipoInspeccionDto>>(response);
        }



    }
}
