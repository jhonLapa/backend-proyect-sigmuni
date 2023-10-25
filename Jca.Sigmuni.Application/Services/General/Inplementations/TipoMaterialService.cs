using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.TipoMateriales;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class TipoMaterialService : ITipoMaterialService
    {
        private readonly IMapper _mapper;
        private readonly ITipoMaterialRepository _tipoMaterialRepository;

        public TipoMaterialService(IMapper mapper, ITipoMaterialRepository tipoMaterialRepository)
        {
            _mapper = mapper;
            _tipoMaterialRepository = tipoMaterialRepository;
        }
        public async Task<IList<TipoMaterialDto>> FindAll()
        {
            var response = await _tipoMaterialRepository.FindAll();

            return _mapper.Map<IList<TipoMaterialDto>>(response);
        }
    }
}
