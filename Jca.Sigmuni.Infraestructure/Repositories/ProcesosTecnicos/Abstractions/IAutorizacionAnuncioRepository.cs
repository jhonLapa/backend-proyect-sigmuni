using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IAutorizacionAnuncioRepository : IRepositoryCrud<AutorizacionAnuncio, int>
    {
        Task<List<AutorizacionAnuncio>> BuscarPorIdTipoAnuncioAsync(int IdTipoAnuncio);
        Task<List<AutorizacionAnuncio>> ListarPorIdFichaAsync(int idFicha);
        Task<bool> EliminarAsync(int id);
    }
}
