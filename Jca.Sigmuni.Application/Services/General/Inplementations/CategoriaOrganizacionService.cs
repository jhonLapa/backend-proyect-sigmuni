using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.CategoriaOrganizaciones;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class CategoriaOrganizacionService : ICategoriaOrganizacionService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaOrganizacionRepository _categoriaOrganizacionRepository;

        public CategoriaOrganizacionService(IMapper mapper, ICategoriaOrganizacionRepository categoriaOrganizacionRepository)
        {
            _mapper = mapper;
            _categoriaOrganizacionRepository = categoriaOrganizacionRepository;
        }
        public async Task<IList<CategoriaOrganizacionDto>> FindAll()
        {
            var response = await _categoriaOrganizacionRepository.FindAll();

            return _mapper.Map<IList<CategoriaOrganizacionDto>>(response);
        }
    }
}
