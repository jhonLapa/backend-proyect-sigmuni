using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface IMedioRegistroRepository
    {
        Task<IList<MedioRegistro>> FindAll();
        Task<MedioRegistro> FindByDescripcion(string descripcion);
    }
}
