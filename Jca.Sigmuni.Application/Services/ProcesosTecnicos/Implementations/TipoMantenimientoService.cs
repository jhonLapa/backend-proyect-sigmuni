using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoMantenimientos;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoMantenimientoService : ITipoMantenimientoService
    {

        private readonly IMapper _mapper;
        private readonly ITipoMantenimientoRepository _tipoMantenimientoRepository;

        public TipoMantenimientoService(IMapper mapper, ITipoMantenimientoRepository tipoMantenimientoRepository)
        {
            _mapper = mapper;
            _tipoMantenimientoRepository = tipoMantenimientoRepository;
        }
        public async Task<IList<TipoMantenimientoDto>> FindAll()
        {
            var response = await _tipoMantenimientoRepository.FindAll();

            return _mapper.Map<IList<TipoMantenimientoDto>>(response);
        }



    }
}
