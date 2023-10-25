using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentoObras;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoDocumentoObraService
    {
        Task<IList<TipoDocumentoObraDto>> FindAll();
    }
}
