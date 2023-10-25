using Jca.Sigmuni.Application.Dtos.Vias.TipoVias;

namespace Jca.Sigmuni.Application.Services.Vias.Abstractions
{
    public interface ITipoViaService
    {
        Task<IList<TipoViaDto>> FindAll();
    }
}
