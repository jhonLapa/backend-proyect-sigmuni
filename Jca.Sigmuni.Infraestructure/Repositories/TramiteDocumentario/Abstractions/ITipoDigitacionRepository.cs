using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface ITipoDigitacionRepository
    {
        Task<IList<TipoDigitacion>> FindAll();

    }
}
