using Jca.Sigmuni.Application.Dtos.General.FiliacionesCronologicas;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IFiliacionCronologicaService
    {
        Task<IList<FiliacionCronologicaDto>> FindAll();
    }
}
