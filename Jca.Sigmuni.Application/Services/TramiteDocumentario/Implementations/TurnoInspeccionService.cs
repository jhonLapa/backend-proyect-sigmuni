using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TurnoInspeccions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class TurnoInspeccionService : ITurnoInspeccionService
    {

        private readonly IMapper _mapper;
        private readonly ITurnoInspeccionRepository _TurnoInspeccionRepository;

        public TurnoInspeccionService(IMapper mapper, ITurnoInspeccionRepository TurnoInspeccionRepository)
        {
            _mapper = mapper;
            _TurnoInspeccionRepository = TurnoInspeccionRepository;
        }
        public async Task<IList<TurnoInspeccionDto>> FindAll()
        {
            var response = await _TurnoInspeccionRepository.FindAll();

            return _mapper.Map<IList<TurnoInspeccionDto>>(response);
        }



    }
}
