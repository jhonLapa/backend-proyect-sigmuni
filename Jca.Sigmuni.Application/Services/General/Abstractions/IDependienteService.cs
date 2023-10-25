using Jca.Sigmuni.Application.Dtos.General.Dependientes;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IDependienteService
    {
        Task<Dependiente?> GuardaronyugeTitularAsync(ConyugeTitularDto peticion);
        Task<Dependiente?> GuardarConyugeLitiganteAsync(ConyugeLitiganteDto peticion);
        Task<bool> EliminarPorIdTitularCatastralAsync(int idTitularCatastral);
    }
}
