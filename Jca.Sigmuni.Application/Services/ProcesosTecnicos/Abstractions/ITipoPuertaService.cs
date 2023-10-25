using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPuertas;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoPuertaService
    {
        Task<IList<TipoPuertaDto>> FindAll();
    }
}
