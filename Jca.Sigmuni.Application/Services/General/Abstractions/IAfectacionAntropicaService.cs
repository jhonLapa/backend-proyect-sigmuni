using Jca.Sigmuni.Application.Dtos.General.AfectacionesAntropicas;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IAfectacionAntropicaService
    {
        Task<IList<AfectacionAntropicaDto>> FindAll();
    }
}
