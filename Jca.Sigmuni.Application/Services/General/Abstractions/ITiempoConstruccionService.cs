using Jca.Sigmuni.Application.Dtos.General.TiemposConstrucciones;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ITiempoConstruccionService
    {
        Task<IList<TiempoConstruccionDto>> FindAll();
    }
}
