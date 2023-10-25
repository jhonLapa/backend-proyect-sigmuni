using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoDocumental;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoPrestamo;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Inplementations
{
    public class TipoPrestamoService : ITipoPrestamoService
    {
        private readonly IMapper _mapper;
        private readonly ITipoPrestamoRepository _tipoPrestamoRepository;

        public TipoPrestamoService(IMapper mapper, ITipoPrestamoRepository tipoPrestamoRepository)
        {
            _mapper = mapper;
            _tipoPrestamoRepository = tipoPrestamoRepository;
        }

        public async Task<TipoPrestamoDto> Create(TipoPrestamoFormDto dto)
        {
            var entity = _mapper.Map<TipoPrestamo>(dto);
            var response = await _tipoPrestamoRepository.Create(entity);

            return _mapper.Map<TipoPrestamoDto>(response);
        }

        public async Task<TipoPrestamoDto?> Disable(int id)
        {
            var response = await _tipoPrestamoRepository.Disable(id);
            return _mapper.Map<TipoPrestamoDto>(response);
        }

        public async Task<TipoPrestamoDto?> Edit(int id, TipoPrestamoFormDto dto)
        {
            var entity = _mapper.Map<TipoPrestamo>(dto);
            var response = await _tipoPrestamoRepository.Edit(id, entity);

            return _mapper.Map<TipoPrestamoDto>(response);
        }

        public async Task<TipoPrestamoDto?> Find(int id)
        {
            var response = await _tipoPrestamoRepository.Find(id);

            return _mapper.Map<TipoPrestamoDto>(response);
        }

        public async Task<IList<TipoPrestamoDto>> FindAll()
        {
            var response = await _tipoPrestamoRepository.FindAll();
            return _mapper.Map<IList<TipoPrestamoDto>>(response);
        }

        public async Task<ResponsePagination<TipoPrestamoDto>> PaginatedSearch(RequestPagination<TipoPrestamoDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<TipoPrestamo>>(dto);
            var response = await _tipoPrestamoRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<TipoPrestamoDto>>(response);
        }
    }
}
