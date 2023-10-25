using Jca.Sigmuni.Application.Dtos.General.TipoMateriales;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ITipoMaterialService
    {
        Task<IList<TipoMaterialDto>> FindAll();
    }
}
