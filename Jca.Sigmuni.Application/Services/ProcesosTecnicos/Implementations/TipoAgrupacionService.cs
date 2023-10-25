using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoAgrupaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoAgrupacionService : ITipoAgrupacionService
    {

        private readonly IMapper _mapper;
        private readonly ITipoAgrupacionRepository _tipoAgrupacionRepository;

        public TipoAgrupacionService(IMapper mapper, ITipoAgrupacionRepository tipoAgrupacionRepository)
        {
            _mapper = mapper;
            _tipoAgrupacionRepository = tipoAgrupacionRepository;
        }
        public async Task<IList<TipoAgrupacionDto>> FindAll()
        {
            var response = await _tipoAgrupacionRepository.FindAll();

            return _mapper.Map<IList<TipoAgrupacionDto>>(response);
        }



    }
}
