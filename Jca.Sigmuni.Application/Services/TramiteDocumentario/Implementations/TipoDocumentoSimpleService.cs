using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDocumentoSimples;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class TipoDocumentoSimpleService : ITipoDocumentoSimpleService
    {

        private readonly IMapper _mapper;
        private readonly ITipoDocumentoSimpleRepository _TipoDocumentoSimpleRepository;

        public TipoDocumentoSimpleService(IMapper mapper, ITipoDocumentoSimpleRepository TipoDocumentoSimpleRepository)
        {
            _mapper = mapper;
            _TipoDocumentoSimpleRepository = TipoDocumentoSimpleRepository;
        }
        public async Task<IList<TipoDocumentoSimpleDto>> FindAll()
        {
            var response = await _TipoDocumentoSimpleRepository.FindAll();

            return _mapper.Map<IList<TipoDocumentoSimpleDto>>(response);
        }



    }
}
