using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.CategoriaInmuebles;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class CategoriaInmuebleService : ICategoriaInmuebleService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaInmuebleRepository _categoriaInmuebleRepository;

        public CategoriaInmuebleService(IMapper mapper, ICategoriaInmuebleRepository categoriaInmuebleRepository)
        {
            _mapper = mapper;
            _categoriaInmuebleRepository = categoriaInmuebleRepository;
        }
        public async Task<IList<CategoriaInmuebleDto>> FindAll()
        {
            var response = await _categoriaInmuebleRepository.FindAll();

            return _mapper.Map<IList<CategoriaInmuebleDto>>(response);
        }
    }
}
