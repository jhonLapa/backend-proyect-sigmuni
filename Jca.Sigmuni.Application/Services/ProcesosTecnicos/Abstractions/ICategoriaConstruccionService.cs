using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CategoriaConstrucciones;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ICategoriaConstruccionService
    {
        Task<IList<CategoriaConstruccionDto>> FindAll();
    }
}
