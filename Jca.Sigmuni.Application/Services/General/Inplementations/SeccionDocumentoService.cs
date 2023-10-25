using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.SeccionDocumentals;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class SeccionDocumentoService : ISeccionDocumentoService
    {
        private readonly IMapper _mapper;
        private readonly ISeccionDocumentalRepository _seccionDocumentalRepository;

        public SeccionDocumentoService(IMapper mapper, ISeccionDocumentalRepository seccionDocumentalRepository)
        {
            _mapper = mapper;
            _seccionDocumentalRepository = seccionDocumentalRepository;
        }
        public async Task<SeccionDocumentalDto> Create(SeccionDocumentalFormDto dto)
        {
            var seccionDocumental = new SeccionDocumental();

            seccionDocumental.Codigo = dto.Codigo;
            seccionDocumental.Descripcion = dto.Descripcion;
            seccionDocumental.Siglas = dto.Siglas;

            var entity = seccionDocumental;
            var response = await _seccionDocumentalRepository.Create(entity);

            return _mapper.Map<SeccionDocumentalDto>(response);
        }
        public async Task<SeccionDocumentalDto?> Disable(int id)
        {
            var response = await _seccionDocumentalRepository.Disable(id);

            return _mapper.Map<SeccionDocumentalDto>(response);
        }
        public async Task<SeccionDocumentalDto?> Edit(int id, SeccionDocumentalFormDto dto)
        {
            var seccionDocumental = new SeccionDocumental();

            seccionDocumental.Codigo = dto.Codigo;
            seccionDocumental.Descripcion = dto.Descripcion;
            seccionDocumental.Siglas = dto.Siglas;

            var entity = seccionDocumental;
            var response = await _seccionDocumentalRepository.Edit(id, entity);

            return _mapper.Map<SeccionDocumentalDto>(response);
        }
        public async Task<SeccionDocumentalDto?> Find(int id)
        {
            var response = await _seccionDocumentalRepository.Find(id);

            return _mapper.Map<SeccionDocumentalDto>(response);
        }
        public async Task<IList<SeccionDocumentalDto>> FindAll()
        {
            var response = await _seccionDocumentalRepository.FindAll();

            return _mapper.Map<IList<SeccionDocumentalDto>>(response);
        }
        public async Task<ResponsePagination<SeccionDocumentalDto>> PaginatedSearch(RequestPagination<SeccionDocumentalDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<SeccionDocumental>>(dto);
            var response = await _seccionDocumentalRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<SeccionDocumentalDto>>(response);
        }
    }
}
