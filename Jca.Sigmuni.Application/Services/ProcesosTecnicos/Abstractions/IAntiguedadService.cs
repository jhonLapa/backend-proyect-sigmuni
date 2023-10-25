using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Antiguedades;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IAntiguedadService
    {
        Task<IList<AntiguedadDto>> FindAll();
    }
}
