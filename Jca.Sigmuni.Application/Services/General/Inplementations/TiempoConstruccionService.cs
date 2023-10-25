using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.TiemposConstrucciones;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class TiempoConstruccionService : ITiempoConstruccionService
    {

        private readonly IMapper _mapper;
        private readonly ITiempoConstruccionRepository _tiempoConstruccionRepository;

        public TiempoConstruccionService(IMapper mapper, ITiempoConstruccionRepository TiempoConstruccionRepository)
        {
            _mapper = mapper;
            _tiempoConstruccionRepository = TiempoConstruccionRepository;
        }
        public async Task<IList<TiempoConstruccionDto>> FindAll()
        {
            var response = await _tiempoConstruccionRepository.FindAll();

            return _mapper.Map<IList<TiempoConstruccionDto>>(response);
        }



    }
}
