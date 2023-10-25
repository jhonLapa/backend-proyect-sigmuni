using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.IntervencionInmuebles;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class IntervencionInmueblesService : IIntervencionInmueblesService
    {
        private readonly IMapper _mapper;
        private readonly IIntervencionInmueblesRepository _intervencionInmueblesRepository;

        public IntervencionInmueblesService(IMapper mapper, IIntervencionInmueblesRepository IntervencionInmueblesRepository)
        {
            _mapper = mapper;
            _intervencionInmueblesRepository = IntervencionInmueblesRepository;
        }
        public async Task<IList<IntervencionInmuebleDto>> FindAll()
        {
            var response = await _intervencionInmueblesRepository.FindAll();

            return _mapper.Map<IList<IntervencionInmuebleDto>>(response);
        }
    }
}
