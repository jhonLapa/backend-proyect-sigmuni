using Jca.Sigmuni.Application.Dtos.General.AfectacionesNaturales;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IAfectacionNaturalService
    {
        Task<IList<AfectacionNaturalDto>> FindAll();
    }
}
