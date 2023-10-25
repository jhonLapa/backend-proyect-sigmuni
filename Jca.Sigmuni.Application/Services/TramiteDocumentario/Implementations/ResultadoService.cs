using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Resultados;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class ResultadoService : IResultadoService
    {

        private readonly IMapper _mapper;
        private readonly IResultadoRepository _ResultadoRepository;

        public ResultadoService(IMapper mapper, IResultadoRepository ResultadoRepository)
        {
            _mapper = mapper;
            _ResultadoRepository = ResultadoRepository;
        }
        public async Task<IList<ResultadoDto>> FindAll()
        {
            var response = await _ResultadoRepository.FindAll();

            return _mapper.Map<IList<ResultadoDto>>(response);
        }



    }
}
