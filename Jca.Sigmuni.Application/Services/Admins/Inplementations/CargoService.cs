using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Cargos;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Implementations;

namespace Jca.Sigmuni.Application.Services.Admins.Inplementations
{
    public class CargoService : ICargoService
    {
        private readonly IMapper _mapper;
        private readonly ICargoRepository _cargoRepository;

        public CargoService(IMapper mapper, ICargoRepository cargoRepository)
        {
            _mapper = mapper;
            _cargoRepository = cargoRepository;
        }

        public async Task<CargoDto> Create(CargoFormDto dto)
        {

            var entity = _mapper.Map<Cargo>(dto);
            var response = await _cargoRepository.Create(entity);

            return _mapper.Map<CargoDto>(response);

        }

        public async Task<CargoDto?> Disable(int id)
        {
            var response = await _cargoRepository.Disable(id);

            return _mapper.Map<CargoDto>(response);
        }

        public async Task<CargoDto?> Edit(int id, CargoFormDto dto)
        {
            var entity = _mapper.Map<Cargo>(dto);
            var response = await _cargoRepository.Edit(id, entity);

            return _mapper.Map<CargoDto>(response);
        }

        public async Task<CargoDto?> Find(int id)
        {
            var response = await _cargoRepository.Find(id);

            return _mapper.Map<CargoDto>(response);
        }

        public async Task<IList<CargoDto>> FindAll()
        {
            var response = await _cargoRepository.FindAll();

            return _mapper.Map<IList<CargoDto>>(response);
        }

        public async Task<ResponsePagination<CargoDto>> PaginatedSearch(RequestPagination<CargoDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Cargo>>(dto);
            var response = await _cargoRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<CargoDto>>(response);
        }
    }
}
