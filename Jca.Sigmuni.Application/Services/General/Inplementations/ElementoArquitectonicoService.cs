using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.ElementosArquitectonicos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class ElementoArquitectonicoService : IElementoArquitectonicoService
    {
        private readonly IMapper _mapper;
        private readonly IElementoArquitectonicoRepository _elementoArquitectonicoRepository;

        public ElementoArquitectonicoService(IMapper mapper, IElementoArquitectonicoRepository elementoArquitectonicoRepository)
        {
            _mapper = mapper;
            _elementoArquitectonicoRepository = elementoArquitectonicoRepository;
        }
        public async Task<IList<ElementoArquitectonicoDto>> FindAll()
        {
            var response = await _elementoArquitectonicoRepository.FindAll();

            return _mapper.Map<IList<ElementoArquitectonicoDto>>(response);
        }
    }
}
