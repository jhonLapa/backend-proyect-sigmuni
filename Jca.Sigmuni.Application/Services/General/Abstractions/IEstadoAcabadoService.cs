using Jca.Sigmuni.Application.Dtos.General.EstadosAcabados;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IEstadoAcabadoService
    {
        Task<IList<EstadoAcabadoDto>> FindAll();
    }
}
