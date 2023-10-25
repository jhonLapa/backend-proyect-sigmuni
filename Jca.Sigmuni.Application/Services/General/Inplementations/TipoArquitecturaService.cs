using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.TipoArquitecturas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class TipoArquitecturaService : ITipoArquitecturaService
    {
        private readonly IMapper _mapper;
        private readonly ITipoArquitecturaRepository _tipoArquitecturaRepository;

        public TipoArquitecturaService(IMapper mapper, ITipoArquitecturaRepository tipoArquitecturaRepository)
        {
            _mapper = mapper;
            _tipoArquitecturaRepository = tipoArquitecturaRepository;
        }
        public async Task<IList<TipoArquitecturaDto>> FindAll()
        {
            var response = await _tipoArquitecturaRepository.FindAll();

            return _mapper.Map<IList<TipoArquitecturaDto>>(response);
        }

        public async Task<IList<TipoArquitecturaDto>> FindAllPorGrupo(string grupo)
        {
            var response = await _tipoArquitecturaRepository.FindAllPorGrupo(grupo);

            return _mapper.Map<IList<TipoArquitecturaDto>>(response);
        }
    }
}
