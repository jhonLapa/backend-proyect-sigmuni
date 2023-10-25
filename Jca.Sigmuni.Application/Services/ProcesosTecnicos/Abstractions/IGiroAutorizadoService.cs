using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.GirosAutorizados;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IGiroAutorizadoService
    {
        Task<IList<GiroAutorizadoDto>> FindAll();
    }
}
