using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UsosPredios;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IUsoPredioService
    {
        Task<IList<UsoPredioDto>> FindAll();
    }
}
