using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ActividadesVerificadas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class ActividadVerificadaService : IActividadVerificadaService
    {

        private readonly IMapper _mapper;
        private readonly IActividadVerificadaRepository _actividadVerificadaRepository;

        public ActividadVerificadaService(IMapper mapper, IActividadVerificadaRepository actividadVerificadaRepository)
        {
            _mapper = mapper;
            _actividadVerificadaRepository = actividadVerificadaRepository;
        }
        public async Task<IList<ActividadVerificadaDto>> FindAll()
        {
            var response = await _actividadVerificadaRepository.FindAll();

            return _mapper.Map<IList<ActividadVerificadaDto>>(response);
        }



    }
}
