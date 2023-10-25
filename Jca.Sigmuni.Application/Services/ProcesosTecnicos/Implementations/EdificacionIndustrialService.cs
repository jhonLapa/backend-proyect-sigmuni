using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EdificacionesIndustriales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class EdificacionIndustrialService : IEdificacionIndustrialService
    {

        private readonly IMapper _mapper;
        private readonly IEdificacionIndustrialRepository _edificacionIndustrialRepository;

        public EdificacionIndustrialService(IMapper mapper, IEdificacionIndustrialRepository edificacionIndustrialRepository)
        {
            _mapper = mapper;
            _edificacionIndustrialRepository = edificacionIndustrialRepository;
        }
        public async Task<IList<EdificacionIndustrialDto>> FindAll()
        {
            var response = await _edificacionIndustrialRepository.FindAll();

            return _mapper.Map<IList<EdificacionIndustrialDto>>(response);
        }



    }
}
