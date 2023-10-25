using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDeclaratorias;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoDeclaratoriaService
    {
        Task<IList<TipoDeclaratoriaDto>> FindAll();
    }
}
