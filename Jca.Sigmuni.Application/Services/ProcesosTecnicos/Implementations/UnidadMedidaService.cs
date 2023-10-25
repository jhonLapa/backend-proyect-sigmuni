using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UnidadMedidas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class UnidadMedidaService : IUnidadMedidaService
    {

        private readonly IMapper _mapper;
        private readonly IUnidadMedidaRepository _unidadMedidaRepository;

        public UnidadMedidaService(IMapper mapper, IUnidadMedidaRepository unidadMedidaRepository)
        {
            _mapper = mapper;
            _unidadMedidaRepository = unidadMedidaRepository;
        }
        public async Task<IList<UnidadMedidaDto>> FindAll()
        {
            var response = await _unidadMedidaRepository.FindAll();

            return _mapper.Map<IList<UnidadMedidaDto>>(response);
        }



    }
}
