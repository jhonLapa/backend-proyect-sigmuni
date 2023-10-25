using Jca.Sigmuni.Application.Dtos.General.TipoArquitecturas;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ITipoArquitecturaService
    {
        Task<IList<TipoArquitecturaDto>> FindAll();
        Task<IList<TipoArquitecturaDto>> FindAllPorGrupo(string grupo);
    }
}
