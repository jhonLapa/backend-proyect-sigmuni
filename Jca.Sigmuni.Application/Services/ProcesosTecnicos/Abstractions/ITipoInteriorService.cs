using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInteriores;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoInteriorService
    {
        Task<IList<TipoInteriorDto>> FindAll();
    }
}
