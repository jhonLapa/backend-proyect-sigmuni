using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDocumentoPresentados;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class TipoDocumentoPresentadoService : ITipoDocumentoPresentadoService
    {

        private readonly IMapper _mapper;
        private readonly ITipoDocumentoPresentadoRepository _TipoDocumentoPresentadoRepository;

        public TipoDocumentoPresentadoService(IMapper mapper, ITipoDocumentoPresentadoRepository TipoDocumentoPresentadoRepository)
        {
            _mapper = mapper;
            _TipoDocumentoPresentadoRepository = TipoDocumentoPresentadoRepository;
        }
        public async Task<IList<TipoDocumentoPresentadoDto>> FindAll()
        {
            var response = await _TipoDocumentoPresentadoRepository.FindAll();

            return _mapper.Map<IList<TipoDocumentoPresentadoDto>>(response);
        }



    }
}