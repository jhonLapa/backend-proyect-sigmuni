using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FormaAdquisiciones;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IFormaAdquisicionService
    {
        Task<IList<FormaAdquisicionDto>> FindAll();
    }
}
