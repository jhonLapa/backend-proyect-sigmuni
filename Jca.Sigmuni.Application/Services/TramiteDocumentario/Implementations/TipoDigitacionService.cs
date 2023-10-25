using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDigitacions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class TipoDigitacionService : ITipoDigitacionService
    {

        private readonly IMapper _mapper;
        private readonly ITipoDigitacionRepository _TipoDigitacionRepository;

        public TipoDigitacionService(IMapper mapper, ITipoDigitacionRepository TipoDigitacionRepository)
        {
            _mapper = mapper;
            _TipoDigitacionRepository = TipoDigitacionRepository;
        }
        public async Task<IList<TipoDigitacionDto>> FindAll()
        {
            var response = await _TipoDigitacionRepository.FindAll();

            return _mapper.Map<IList<TipoDigitacionDto>>(response);
        }



    }
}
