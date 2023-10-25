using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.EstadosAcabados;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class EstadoAcabadoService : IEstadoAcabadoService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoAcabadoRepository _estadoAcabadoRepository;

        public EstadoAcabadoService(IMapper mapper, IEstadoAcabadoRepository estadoAcabadoRepository)
        {
            _mapper = mapper;
            _estadoAcabadoRepository = estadoAcabadoRepository;
        }
        public async Task<IList<EstadoAcabadoDto>> FindAll()
        {
            var response = await _estadoAcabadoRepository.FindAll();

            return _mapper.Map<IList<EstadoAcabadoDto>>(response);
        }
    }
}
