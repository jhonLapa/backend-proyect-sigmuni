using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoInformes;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class TipoInformeService : ITipoInformeService
    {

        private readonly IMapper _mapper;
        private readonly ITipoInformeRepository _TipoInformeRepository;

        public TipoInformeService(IMapper mapper, ITipoInformeRepository TipoInformeRepository)
        {
            _mapper = mapper;
            _TipoInformeRepository = TipoInformeRepository;
        }
        public async Task<IList<TipoInformeDto>> FindAll()
        {
            var response = await _TipoInformeRepository.FindAll();

            return _mapper.Map<IList<TipoInformeDto>>(response);
        }



    }
}