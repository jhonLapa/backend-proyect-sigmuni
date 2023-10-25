using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentosFichas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoDocumentoFichaService : ITipoDocumentoFichaService
    {
        private readonly IMapper _mapper;
        private readonly ITipoDocumentoFichaRepository _tipoDocumentoFichaRepository;

        public TipoDocumentoFichaService(IMapper mapper, ITipoDocumentoFichaRepository tipoDocumentoFichaRepository)
        {
            _mapper = mapper;
            _tipoDocumentoFichaRepository = tipoDocumentoFichaRepository;
        }
        public async Task<IList<TipoDocumentoFichaDto>> FindAll()
        {
            var response = await _tipoDocumentoFichaRepository.FindAll();

            return _mapper.Map<IList<TipoDocumentoFichaDto>>(response);
        }
    }
}
