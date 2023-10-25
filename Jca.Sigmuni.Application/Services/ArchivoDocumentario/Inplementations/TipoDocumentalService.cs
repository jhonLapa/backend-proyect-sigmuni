using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoDocumental;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Implementations;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Inplementations
{
    public class TipoDocumentalService : ITipoDocumentalService
    {
        private readonly IMapper _mapper;
        private readonly ITipoDocumentalRepository _tipoDocumentalRepository;

        public TipoDocumentalService(IMapper mapper, ITipoDocumentalRepository tipoDocumentalRepository)
        {
            _mapper = mapper;
            _tipoDocumentalRepository = tipoDocumentalRepository;
        }

        public async Task<TipoDocumentalDto> Create(TipoDocumentalFormDto dto)
        {
            var entity = _mapper.Map<TipoDocumental>(dto);
            var response = await _tipoDocumentalRepository.Create(entity);

            return _mapper.Map<TipoDocumentalDto>(response);
        }

        public async Task<TipoDocumentalDto?> Disable(int id)
        {
            var response = await _tipoDocumentalRepository.Disable(id);
            return _mapper.Map<TipoDocumentalDto>(response);
        }

        public async Task<TipoDocumentalDto?> Edit(int id, TipoDocumentalFormDto dto)
        {
            var entity = _mapper.Map<TipoDocumental>(dto);
            var response = await _tipoDocumentalRepository.Edit(id, entity);

            return _mapper.Map<TipoDocumentalDto>(response);
        }

        public async Task<TipoDocumentalDto?> Find(int id)
        {
            var response = await _tipoDocumentalRepository.Find(id);

            return _mapper.Map<TipoDocumentalDto>(response);
        }

        public async Task<IList<TipoDocumentalDto>> FindAll()
        {
            var response = await _tipoDocumentalRepository.FindAll();
            return _mapper.Map<IList<TipoDocumentalDto>>(response);
        }

        public async Task<ResponsePagination<TipoDocumentalDto>> PaginatedSearch(RequestPagination<TipoDocumentalDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<TipoDocumental>>(dto);
            var response = await _tipoDocumentalRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<TipoDocumentalDto>>(response);
        }
    }
}
