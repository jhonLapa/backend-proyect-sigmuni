using Jca.Sigmuni.Application.Dtos.General.CategoriaOrganizaciones;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ICategoriaOrganizacionService
    {
        Task<IList<CategoriaOrganizacionDto>> FindAll();
    }
}
