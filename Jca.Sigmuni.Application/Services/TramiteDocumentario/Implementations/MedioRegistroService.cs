using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.MedioRegistros;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class MedioRegistroService : IMedioRegistroService
    {

        private readonly IMapper _mapper;
        private readonly IMedioRegistroRepository _MedioRegistroRepository;

        public MedioRegistroService(IMapper mapper, IMedioRegistroRepository MedioRegistroRepository)
        {
            _mapper = mapper;
            _MedioRegistroRepository = MedioRegistroRepository;
        }
        public async Task<IList<MedioRegistroDto>> FindAll()
        {
            var response = await _MedioRegistroRepository.FindAll();

            return _mapper.Map<IList<MedioRegistroDto>>(response);
        }



    }
}