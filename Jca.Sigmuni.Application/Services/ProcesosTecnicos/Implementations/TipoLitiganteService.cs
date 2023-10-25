using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoLitigantes;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoLitiganteService : ITipoLitiganteService
    {

        private readonly IMapper _mapper;
        private readonly ITipoLitiganteRepository _tipoLitiganteRepository;

        public TipoLitiganteService(IMapper mapper, ITipoLitiganteRepository tipoLitiganteRepository)
        {
            _mapper = mapper;
            _tipoLitiganteRepository = tipoLitiganteRepository;
        }
        public async Task<IList<TipoLitiganteDto>> FindAll()
        {
            var response = await _tipoLitiganteRepository.FindAll();

            return _mapper.Map<IList<TipoLitiganteDto>>(response);
        }



    }
}
