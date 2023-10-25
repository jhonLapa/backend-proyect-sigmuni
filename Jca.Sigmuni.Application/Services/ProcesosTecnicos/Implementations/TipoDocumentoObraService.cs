using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentoObras;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoDocumentoObraService : ITipoDocumentoObraService
    {

        private readonly IMapper _mapper;
        private readonly ITipoDocumentoObraRepository _tipoDocumentoObraRepository;

        public TipoDocumentoObraService(IMapper mapper, ITipoDocumentoObraRepository tipoDocumentoObraRepository)
        {
            _mapper = mapper;
            _tipoDocumentoObraRepository = tipoDocumentoObraRepository;
        }
        public async Task<IList<TipoDocumentoObraDto>> FindAll()
        {
            var response = await _tipoDocumentoObraRepository.FindAll();

            return _mapper.Map<IList<TipoDocumentoObraDto>>(response);
        }



    }
}
