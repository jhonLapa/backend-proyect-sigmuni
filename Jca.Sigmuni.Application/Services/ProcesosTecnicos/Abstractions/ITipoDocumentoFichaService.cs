using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentosFichas;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoDocumentoFichaService
    {
        Task<IList<TipoDocumentoFichaDto>> FindAll();
    }
}
