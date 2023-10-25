using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.TipoHabilitacionesUrbanas;
using Jca.Sigmuni.Application.Services.Habilitaciones.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Habilitaciones.Abstracciones;

namespace Jca.Sigmuni.Application.Services.Habilitaciones.Implementations
{
    public class TipoHabilitacionUrbanaService : ITipoHabilitacionUrbanaService
    {

        private readonly IMapper _mapper;
        private readonly ITipoHabilitacionUrbanaRepository _tipoHabilitacionUrbanaRepository;

        public TipoHabilitacionUrbanaService(IMapper mapper, ITipoHabilitacionUrbanaRepository tipoHabilitacionUrbanaRepository)
        {
            _mapper = mapper;
            _tipoHabilitacionUrbanaRepository = tipoHabilitacionUrbanaRepository;
        }
        public async Task<IList<TipoHabilitacionUrbanaDto>> FindAll()
        {
            var response = await _tipoHabilitacionUrbanaRepository.FindAll();

            return _mapper.Map<IList<TipoHabilitacionUrbanaDto>>(response);
        }



    }
}
