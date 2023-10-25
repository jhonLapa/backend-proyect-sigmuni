using Jca.Sigmuni.Application.Dtos.General.FiliacionesEstilisticas;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IFiliacionEstilisticaService
    {
        Task<IList<FiliacionEstilisticaDto>> FindAll();
    }
}
