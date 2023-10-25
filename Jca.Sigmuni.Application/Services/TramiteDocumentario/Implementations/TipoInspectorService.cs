using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoInspectors;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class TipoInspectorService : ITipoInspectorService
    {

        private readonly IMapper _mapper;
        private readonly ITipoInspectorRepository _TipoInspectorRepository;

        public TipoInspectorService(IMapper mapper, ITipoInspectorRepository TipoInspectorRepository)
        {
            _mapper = mapper;
            _TipoInspectorRepository = TipoInspectorRepository;
        }
        public async Task<IList<TipoInspectorDto>> FindAll()
        {
            var response = await _TipoInspectorRepository.FindAll();

            return _mapper.Map<IList<TipoInspectorDto>>(response);
        }



    }
}
