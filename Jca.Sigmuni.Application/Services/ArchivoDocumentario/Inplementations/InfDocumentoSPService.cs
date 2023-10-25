using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Inplementations
{
    public class InfDocumentoSPService : IInfDocumentoSPService
    {
        private readonly IMapper _mapper;
        private readonly IInfDocumentoSPRepository _infDocumentoSPRepository;

        public InfDocumentoSPService(IMapper mapper, IInfDocumentoSPRepository infDocumentoSPRepository)
        {
            _mapper = mapper;
            _infDocumentoSPRepository = infDocumentoSPRepository;
        }
        public Task<InfDocumentoSPDto> Create(InfDocumentoSPFormDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<InfDocumentoSPDto?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InfDocumentoSPDto?> Edit(int id, InfDocumentoSPFormDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<InfDocumentoSPDto?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<InfDocumentoSPDto>> FindAll()
        {
            throw new NotImplementedException();
        }
        public async Task<InfDocumentoSPDto?> ListarDetalleAsync(string numExpendiente, string anioExpediente)
        {
            var entidad = await _infDocumentoSPRepository.ListarDetalleAsync(numExpendiente, anioExpediente);
            return _mapper.Map<InfDocumentoSPDto>(entidad);
        }
        public async Task<ResponsePagination<InfDocumentoSPDto>> PaginatedSearch(RequestPagination<InfDocumentoSPDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<InfDocumento>>(dto);
            var response = await _infDocumentoSPRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<InfDocumentoSPDto>>(response);
        }
    }
}
