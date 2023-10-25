using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class DocumentoIdentidadService : IDocumentoIdentidadService
    {
        private readonly IMapper _mapper;
        private readonly IDocumentoIdentidadRepository _documentoIdentidadRepository;

        public DocumentoIdentidadService(IMapper mapper, IDocumentoIdentidadRepository documentoIdentidadRepository)
        {
            _mapper = mapper;
            _documentoIdentidadRepository = documentoIdentidadRepository;
        }

        public async Task<DocumentoIdentidadDto> Create(DocumentoIdentidadFormDto dto)
        {

            var entity = _mapper.Map<DocumentoIdentidad>(dto);
            var response = await _documentoIdentidadRepository.Create(entity);

            return _mapper.Map<DocumentoIdentidadDto>(response);

        }

        public async Task<DocumentoIdentidadDto?> Disable(int id)
        {
            var response = await _documentoIdentidadRepository.Disable(id);

            return _mapper.Map<DocumentoIdentidadDto>(response);
        }

        public async Task<DocumentoIdentidadDto?> Edit(int id, DocumentoIdentidadFormDto dto)
        {
            var entity = _mapper.Map<DocumentoIdentidad>(dto);
            var response = await _documentoIdentidadRepository.Edit(id, entity);

            return _mapper.Map<DocumentoIdentidadDto>(response);
        }

        public async Task<DocumentoIdentidadDto?> Find(int id)
        {
            var response = await _documentoIdentidadRepository.Find(id);

            return _mapper.Map<DocumentoIdentidadDto>(response);
        }

        public async Task<IList<DocumentoIdentidadDto>> FindAll()
        {
            var response = await _documentoIdentidadRepository.FindAll();

            return _mapper.Map<IList<DocumentoIdentidadDto>>(response);
        }

        public async Task<ResponsePagination<DocumentoIdentidadDto>> PaginatedSearch(RequestPagination<DocumentoIdentidadDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<DocumentoIdentidad>>(dto);
            var response = await _documentoIdentidadRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<DocumentoIdentidadDto>>(response);
        }
    }

}
