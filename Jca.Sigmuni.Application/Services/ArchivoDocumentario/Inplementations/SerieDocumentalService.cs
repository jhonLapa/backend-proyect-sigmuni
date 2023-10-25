using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SerieDocumental;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Inplementations
{
    public class SerieDocumentalService : ISerieDocumentalService
    {
        private readonly IMapper _mapper;
        private readonly ISerieDocumentalRepository _serieDocumentalRepository;

        public SerieDocumentalService(IMapper mapper, ISerieDocumentalRepository serieDocumentalRepository)
        {
            _mapper = mapper;
            _serieDocumentalRepository = serieDocumentalRepository;
        }

        public async Task<SerieDocumentalDto> Create(SerieDocumentalFormDto dto)
        {
            var entity = _mapper.Map<SerieDocumental>(dto);
            var response = await _serieDocumentalRepository.Create(entity);

            return _mapper.Map<SerieDocumentalDto>(response);
        }

        public async Task<SerieDocumentalDto?> Disable(int id)
        {
            var response = await _serieDocumentalRepository.Disable(id);
            return _mapper.Map<SerieDocumentalDto>(response);
        }

        public async Task<SerieDocumentalDto?> Edit(int id, SerieDocumentalFormDto dto)
        {
            var entity = _mapper.Map<SerieDocumental>(dto);
            var response = await _serieDocumentalRepository.Edit(id, entity);

            return _mapper.Map<SerieDocumentalDto>(response);
        }

        public async Task<SerieDocumentalDto?> Find(int id)
        {
            var response = await _serieDocumentalRepository.Find(id);

            return _mapper.Map<SerieDocumentalDto>(response);
        }

        public async Task<IList<SerieDocumentalDto>> FindAll()
        {
            var response = await _serieDocumentalRepository.FindAll();
            return _mapper.Map<IList<SerieDocumentalDto>>(response);
        }

        public async Task<ResponsePagination<SerieDocumentalDto>> PaginatedSearch(RequestPagination<SerieDocumentalDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<SerieDocumental>>(dto);
            var response = await _serieDocumentalRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<SerieDocumentalDto>>(response);
        }
    }
}
