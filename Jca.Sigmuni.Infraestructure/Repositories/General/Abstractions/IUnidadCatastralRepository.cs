using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IUnidadCatastralRepository : IRepositoryCrud<UnidadCatastral, int>
    {
        Task<IList<UnidadCatastral>> FindAll();
        Task<UnidadCatastral> ObtenerPorCodigoCatastralAsync(TblCodigo peticion);
        Task<List<UnidadCatastral>> ObtenerPorIdLoteCartoAsync(string? idLoteCarto);
        Task<List<UnidadCatastral>> ObtenerPorCodigoCatastralBienComunAsync(TblCodigo peticion);
        Task<UnidadCatastral?> MaximoCUCAsync(string lote);
    }
}
