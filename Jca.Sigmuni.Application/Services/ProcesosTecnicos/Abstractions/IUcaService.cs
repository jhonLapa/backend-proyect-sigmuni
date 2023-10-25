using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ucas;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IUcaService
    {
        Task<IList<UcaDto>> FindAll();
    }
}
