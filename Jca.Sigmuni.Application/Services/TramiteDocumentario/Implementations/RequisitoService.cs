using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Requisitos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class RequisitoService : IRequisitoService
    {

        private readonly IMapper _mapper;
        private readonly IRequisitoRepository _RequisitoRepository;

        public RequisitoService(IMapper mapper, IRequisitoRepository RequisitoRepository)
        {
            _mapper = mapper;
            _RequisitoRepository = RequisitoRepository;
        }
        public async Task<IList<RequisitoDto>> FindAll()
        {
            var response = await _RequisitoRepository.FindAll();

            return _mapper.Map<IList<RequisitoDto>>(response);
        }
        public async Task<RequisitoDto?> Find(int id)
        {
            var response = await _RequisitoRepository.Find(id);

            return _mapper.Map<RequisitoDto>(response);
        }

        public async Task<RequisitoDto?> Disable(int id)
        {
            var response = await _RequisitoRepository.Disable(id);

            return _mapper.Map<RequisitoDto>(response);
        }

        public async Task<RequisitoDto?> Edit(int id, RequisitoFormDto dto)
        {
            var entity = _mapper.Map<Requisito>(dto);
            var response = await _RequisitoRepository.Edit(id, entity);

            return _mapper.Map<RequisitoDto>(response);
        }

        public async Task<RequisitoDto> Create(RequisitoFormDto dto)
        {

            var entity = _mapper.Map<Requisito>(dto);
            var response = await _RequisitoRepository.Create(entity);

            return _mapper.Map<RequisitoDto>(response);

        }

        public async Task<ResponsePagination<RequisitoDto>> PaginatedSearch(RequestPagination<RequisitoDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Requisito>>(dto);
            var response = await _RequisitoRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<RequisitoDto>>(response);
        }



    }
}
