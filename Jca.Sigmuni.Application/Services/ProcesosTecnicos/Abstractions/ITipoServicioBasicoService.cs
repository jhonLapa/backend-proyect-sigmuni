using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoServiciosBasicos;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoServicioBasicoService
    {
        Task<IList<TipoServicioBasicoDto>> FindAll();
        Task<List<TipoServicioBasicoDto>> ListarGrupoAsync(string grupo);
    }
}
