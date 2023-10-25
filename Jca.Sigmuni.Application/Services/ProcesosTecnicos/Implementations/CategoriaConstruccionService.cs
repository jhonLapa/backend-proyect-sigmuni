using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CategoriaConstrucciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class CategoriaConstruccionService : ICategoriaConstruccionService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaConstruccionRepository _categoriaConstruccionRepository;

        public CategoriaConstruccionService(IMapper mapper, ICategoriaConstruccionRepository categoriaConstruccionRepository)
        {
            _mapper = mapper;
            _categoriaConstruccionRepository = categoriaConstruccionRepository;
        }
        public async Task<IList<CategoriaConstruccionDto>> FindAll()
        {
            var response = await _categoriaConstruccionRepository.FindAll();

            return _mapper.Map<IList<CategoriaConstruccionDto>>(response);
        }
    }
}
