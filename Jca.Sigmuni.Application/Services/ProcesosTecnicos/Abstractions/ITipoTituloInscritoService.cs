using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoTituloInscritos;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoTituloInscritoService
    {
        Task<IList<TipoTituloInscritoDto>> FindAll();
    }
}
