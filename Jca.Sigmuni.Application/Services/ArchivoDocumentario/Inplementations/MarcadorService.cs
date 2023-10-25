using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Marcadores;
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
    public class MarcadorService : IMarcadorService
    {
        private readonly IMapper _mapper;
        private readonly IMarcadorRepository _marcadorRepository;

        public MarcadorService(IMapper mapper, IMarcadorRepository marcadorRepository)
        {
            _mapper = mapper;
            _marcadorRepository = marcadorRepository;
        }

        public async Task<MarcadorDto> Create(MarcadorFormDto dto)
        {
            var entity = _mapper.Map<Marcador>(dto);
            var response = await _marcadorRepository.Create(entity);

            return _mapper.Map<MarcadorDto>(response);
        }

        public async Task<MarcadorDto?> Disable(int id)
        {
            var response = await _marcadorRepository.Disable(id);
            return _mapper.Map<MarcadorDto>(response);
        }

        public async Task<MarcadorDto?> Edit(int id, MarcadorFormDto dto)
        {
            var entity = _mapper.Map<Marcador>(dto);
            var response = await _marcadorRepository.Edit(id, entity);

            return _mapper.Map<MarcadorDto>(response);
        }

        public async Task<MarcadorDto?> Find(int id)
        {
            var response = await _marcadorRepository.Find(id);

            return _mapper.Map<MarcadorDto>(response);
        }

        public async Task<IList<MarcadorDto>> FindAll()
        {
            var response = await _marcadorRepository.FindAll();
            return _mapper.Map<IList<MarcadorDto>>(response);
        }

        public async Task<ResponsePagination<MarcadorDto>> PaginatedSearch(RequestPagination<MarcadorDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Marcador>>(dto);
            var response = await _marcadorRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<MarcadorDto>>(response);
        }
    }
}
