using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface ITipoArquitecturaRepository
    {
        Task<IList<TipoArquitectura>> FindAll();
        Task<IList<TipoArquitectura>> FindAllPorGrupo(string grupo);
    }
}
