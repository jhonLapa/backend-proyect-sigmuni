using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionAnuncios;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ICondicionAnuncioService
    {
        Task<IList<CondicionAnuncioDto>> FindAll();
    }
}
