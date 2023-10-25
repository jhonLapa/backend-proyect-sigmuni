using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.IntervencionesConservaciones;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class IntervencionConservacionService : IIntervencionConservacionService
    {
        private readonly IMapper _mapper;
        private readonly IIntervencionConservacionRepository _intervencionConservacionRepository;

        public IntervencionConservacionService(IMapper mapper, IIntervencionConservacionRepository intervencionConservacionRepository)
        {
            _mapper = mapper;
            _intervencionConservacionRepository = intervencionConservacionRepository;
        }
        public async Task<IList<IntervencionConservacionDto>> FindAll()
        {
            var response = await _intervencionConservacionRepository.FindAll();

            return _mapper.Map<IList<IntervencionConservacionDto>>(response);
        }
    }
}
