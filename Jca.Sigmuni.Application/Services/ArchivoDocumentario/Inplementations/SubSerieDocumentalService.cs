using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SerieDocumental;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SubSerieDocumental;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Inplementations
{
    public class SubSerieDocumentalService : ISubSerieDocumentalService
    {
        private readonly IMapper _mapper;
        private readonly ISubSerieDocumentalRepository _subSerieDocumentalRepository;

        public SubSerieDocumentalService(IMapper mapper, ISubSerieDocumentalRepository subSerieDocumentalRepository)
        {
            _mapper = mapper;
            _subSerieDocumentalRepository = subSerieDocumentalRepository;
        }

        public async Task<SubSerieDocumentalDto> Create(SubSerieDocumentalFormDto dto)
        {
            var entity = _mapper.Map<SubSerieDocumental>(dto);
            var response = await _subSerieDocumentalRepository.Create(entity);
            return _mapper.Map<SubSerieDocumentalDto>(response);
        }

        public async Task<SubSerieDocumentalDto?> Disable(int id)
        {
            var response = await _subSerieDocumentalRepository.Disable(id);
            return _mapper.Map<SubSerieDocumentalDto>(response);
        }

        public async Task<SubSerieDocumentalDto?> Edit(int id, SubSerieDocumentalFormDto dto)
        {
            var entity = _mapper.Map<SubSerieDocumental>(dto);
            var response = await _subSerieDocumentalRepository.Edit(id, entity);

            return _mapper.Map<SubSerieDocumentalDto>(response);
        }

        public async Task<SubSerieDocumentalDto?> Find(int id)
        {
            var response = await _subSerieDocumentalRepository.Find(id);

            return _mapper.Map<SubSerieDocumentalDto>(response);
        }

        public async Task<IList<SubSerieDocumentalDto>> FindAll()
        {
            var response = await _subSerieDocumentalRepository.FindAll();
            return _mapper.Map<IList<SubSerieDocumentalDto>>(response);
        }

        public async Task<ResponsePagination<SubSerieDocumentalDto>> PaginatedSearch(RequestPagination<SubSerieDocumentalDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<SubSerieDocumental>>(dto);
            var response = await _subSerieDocumentalRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<SubSerieDocumentalDto>>(response);
        }
    }
}
