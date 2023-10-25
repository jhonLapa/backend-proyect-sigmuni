using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.EstadoCivil;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class EstadoCivilService : IEstadoCivilService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoCivilRepository _estadoCivilRepository;

        public EstadoCivilService(IMapper mapper, IEstadoCivilRepository estadoCivilRepository)
        {
            _mapper = mapper;
            _estadoCivilRepository = estadoCivilRepository;
        }

        public async Task<EstadoCivilDto> Create(EstadoCivilFormDto dto)
        {

            var entity = _mapper.Map<EstadoCivil>(dto);
            var response = await _estadoCivilRepository.Create(entity);

            return _mapper.Map<EstadoCivilDto>(response);

        }

        public async Task<EstadoCivilDto?> Disable(int id)
        {
            var response = await _estadoCivilRepository.Disable(id);

            return _mapper.Map<EstadoCivilDto>(response);
        }

        public async Task<EstadoCivilDto?> Edit(int id, EstadoCivilFormDto dto)
        {
            var entity = _mapper.Map<EstadoCivil>(dto);
            var response = await _estadoCivilRepository.Edit(id, entity);

            return _mapper.Map<EstadoCivilDto>(response);
        }

        public async Task<EstadoCivilDto?> Find(int id)
        {
            var response = await _estadoCivilRepository.Find(id);

            return _mapper.Map<EstadoCivilDto>(response);
        }

        public async Task<IList<EstadoCivilDto>> FindAll()
        {
            var response = await _estadoCivilRepository.FindAll();

            return _mapper.Map<IList<EstadoCivilDto>>(response);
        }

        public async Task<ResponsePagination<EstadoCivilDto>> PaginatedSearch(RequestPagination<EstadoCivilDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<EstadoCivil>>(dto);
            var response = await _estadoCivilRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<EstadoCivilDto>>(response);
        }
    }

}
