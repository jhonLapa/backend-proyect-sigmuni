using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocNotariales;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoDocNotarialService
    {
        Task<IList<TipoDocNotarialDto>> FindAll();
    }
}
