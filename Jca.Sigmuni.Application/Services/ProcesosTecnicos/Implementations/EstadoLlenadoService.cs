using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EstadosLlenados;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class EstadoLlenadoService : IEstadoLlenadoService
    {

        private readonly IMapper _mapper;
        private readonly IEstadoLlenadoRepository _estadoLlenadoRepository;

        public EstadoLlenadoService(IMapper mapper, IEstadoLlenadoRepository estadoLlenadoRepository)
        {
            _mapper = mapper;
            _estadoLlenadoRepository = estadoLlenadoRepository;
        }
        public async Task<IList<EstadoLlenadoDto>> FindAll()
        {
            var response = await _estadoLlenadoRepository.FindAll();

            return _mapper.Map<IList<EstadoLlenadoDto>>(response);
        }



    }
}
