using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IUnidadCatastralService : IServiceBase<UnidadCatastralDto, UnidadCatastralFormDto, int>
    {
        Task<IList<UnidadCatastralDto>> FindAll();
        Task<int> ActualizarAsync(UnidadCatastralDto peticion);
    }
}
