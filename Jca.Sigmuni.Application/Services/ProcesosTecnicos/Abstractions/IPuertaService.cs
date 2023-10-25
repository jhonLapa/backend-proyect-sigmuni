using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Puertas;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IPuertaService
    {
        Task<List<PuertaDto>> ListarPorUbicacionPredioAsync(int idUbicacionPredio);
        Task<bool> EliminarAsync(int id);
        Task<bool> EliminarPorListaAsync(List<PuertaDto> puertas);
        Task<Puerta?> GuardarAsync(PuertaDto peticion);
        Task<IList<PuertaDto>> FindAll();
    }
}
