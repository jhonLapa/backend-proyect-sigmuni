using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EstadosLlenados;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IEstadoLlenadoService
    {
        Task<IList<EstadoLlenadoDto>> FindAll();
    }
}
