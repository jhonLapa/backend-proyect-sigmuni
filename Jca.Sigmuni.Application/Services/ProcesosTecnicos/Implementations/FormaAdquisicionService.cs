using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FormaAdquisiciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class FormaAdquisicionService : IFormaAdquisicionService
    {

        private readonly IMapper _mapper;
        private readonly IFormaAdquisicionRepository _formaAdquisicionRepository;

        public FormaAdquisicionService(IMapper mapper, IFormaAdquisicionRepository formaAdquisicionRepository)
        {
            _mapper = mapper;
            _formaAdquisicionRepository = formaAdquisicionRepository;
        }
        public async Task<IList<FormaAdquisicionDto>> FindAll()
        {
            var response = await _formaAdquisicionRepository.FindAll();

            return _mapper.Map<IList<FormaAdquisicionDto>>(response);
        }



    }
}
