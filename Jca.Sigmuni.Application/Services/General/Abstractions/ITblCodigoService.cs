using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ITblCodigoService : IServicePaginated<TblCodigoCatastralDto>
    {
        Task<TblCodigo?> CrearOActualizarCodigoCatastralAsync(TblCodigoCatastralDto peticion);
        Task<TblCodigo?> CrearOActualizarCodigoCatastralReferencialAsync(TblCodigoCatastralRefDto peticion);
        Task<TblCodigoCatastralDto> BuscarPorIdFichaAsync(int idFicha);
    }
}
