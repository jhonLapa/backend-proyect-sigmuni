using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosPrehispanicos;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IMonumentoPrehispanicoService
    {
    Task<int?> CrearOActualizarAsync(MonumentoPrehispanicoDto peticion);
}
}
