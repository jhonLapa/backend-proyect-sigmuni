using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoServicioBasicoRepository
    {
        Task<IList<TipoServicioBasico>> FindAll();
        Task<List<TipoServicioBasico>> ListarGrupoAsync(string grupo);
    }
}
