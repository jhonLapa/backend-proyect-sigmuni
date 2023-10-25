using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface ICategoriaOrganizacionRepository
    {
        Task<IList<CategoriaOrganizacion>> FindAll();
    }
}
