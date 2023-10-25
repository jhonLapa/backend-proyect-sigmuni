using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoAnuncios;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoAnuncioService
    {
        Task<IList<TipoAnuncioDto>> FindAll();
    }
}
