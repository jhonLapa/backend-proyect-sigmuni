using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoFichas;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoFichaService
    {
        Task<IList<TipoFichaDto>> FindAll();
    }
}
