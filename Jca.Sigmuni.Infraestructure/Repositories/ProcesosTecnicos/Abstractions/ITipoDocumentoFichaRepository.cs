using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoDocumentoFichaRepository
    {
        Task<IList<TipoDocumentoFicha>> FindAll();
    }
}
