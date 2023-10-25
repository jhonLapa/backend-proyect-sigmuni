using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Observaciones;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class ObservacionService : IObservacionService
    {

        private readonly IMapper _mapper;
        private readonly IObservacionRepository _observacionRepository;

        public ObservacionService(IMapper mapper, IObservacionRepository observacionRepository)
        {
            _mapper = mapper;
            _observacionRepository = observacionRepository;
        }
        public async Task<IList<ObservacionDto>> FindAll()
        {
            var response = await _observacionRepository.FindAll();

            return _mapper.Map<IList<ObservacionDto>>(response);
        }



    }
}
