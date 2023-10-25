using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class TipoPersonaService : ITipoPersonaService
    {
        private readonly IMapper _mapper;
        private readonly ITipoPersonaRepository _tipoPersonaRepository;

        public TipoPersonaService(IMapper mapper, ITipoPersonaRepository tipoPersonaRepository)
        {
            _mapper = mapper;
            _tipoPersonaRepository = tipoPersonaRepository;
        }

        public async Task<TipoPersonaDto> Create(TipoPersonaFormDto dto)
        {

            var entity = _mapper.Map<TipoPersona>(dto);
            var response = await _tipoPersonaRepository.Create(entity);

            return _mapper.Map<TipoPersonaDto>(response);

        }

        public async Task<TipoPersonaDto?> Disable(int id)
        {
            var response = await _tipoPersonaRepository.Disable(id);

            return _mapper.Map<TipoPersonaDto>(response);
        }

        public async Task<TipoPersonaDto?> Edit(int id, TipoPersonaFormDto dto)
        {
            var entity = _mapper.Map<TipoPersona>(dto);
            var response = await _tipoPersonaRepository.Edit(id, entity);

            return _mapper.Map<TipoPersonaDto>(response);
        }

        public async Task<TipoPersonaDto?> Find(int id)
        {
            var response = await _tipoPersonaRepository.Find(id);

            return _mapper.Map<TipoPersonaDto>(response);
        }

        public async Task<IList<TipoPersonaDto>> FindAll()
        {
            var response = await _tipoPersonaRepository.FindAll();

            return _mapper.Map<IList<TipoPersonaDto>>(response);
        }

        public async Task<ResponsePagination<TipoPersonaDto>> PaginatedSearch(RequestPagination<TipoPersonaDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<TipoPersona>>(dto);
            var response = await _tipoPersonaRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<TipoPersonaDto>>(response);
        }
    }

}
