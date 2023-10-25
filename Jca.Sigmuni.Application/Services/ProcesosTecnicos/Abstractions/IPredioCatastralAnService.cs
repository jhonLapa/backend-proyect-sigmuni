using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PredioCatastralesAn;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IPredioCatastralAnService
    {
        Task<IList<PredioCatastralAnDto>> FindAll();
    }
}
