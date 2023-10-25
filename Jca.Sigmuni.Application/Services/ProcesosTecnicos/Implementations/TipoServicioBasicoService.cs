using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoServiciosBasicos;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoServicioBasicoService : ITipoServicioBasicoService
    {

        private readonly IMapper _mapper;
        private readonly ITipoServicioBasicoRepository _tipoServicioBasicoRepository;

        public TipoServicioBasicoService(IMapper mapper, ITipoServicioBasicoRepository tipoServicioBasicoRepository)
        {
            _mapper = mapper;
            _tipoServicioBasicoRepository = tipoServicioBasicoRepository;
        }
        public async Task<IList<TipoServicioBasicoDto>> FindAll()
        {
            var response = await _tipoServicioBasicoRepository.FindAll();

            return _mapper.Map<IList<TipoServicioBasicoDto>>(response);
        }

        public async Task<List<TipoServicioBasicoDto>> ListarGrupoAsync(string grupo)
        {
            var entidad = await _tipoServicioBasicoRepository.ListarGrupoAsync(grupo);

            return _mapper.Map<List<TipoServicioBasicoDto>>(entidad.OrderBy(e => e.Codigo));
        }

    }
}
