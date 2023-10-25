using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface ILoteRepository 
    {
        Task<IList<Lote>> FindAll();

        Task<ResponsePagination<Lote>> PaginatedSearch(RequestPagination<Lote> entity);
        Task<Lote?> Find(string id);
        Task<Lote?> BuscarCucMaximo();
        Task<bool?> EditLote(Lote entity);
        Task<LoteDetalle> ObtenerCabeceraPorLote(string idLoteCarto);
        Task<List<LoteDetalleVia>> ObtenerDetallePorLote(string idLoteCarto);
    }
}
