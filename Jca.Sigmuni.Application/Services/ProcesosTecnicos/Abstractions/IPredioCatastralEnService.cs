using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PrediosCatastralesEn;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IPredioCatastralEnService
    {
        Task<IList<PredioCatastralEnDto>> FindAll();
    }
}
