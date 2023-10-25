using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoPrestamo;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions
{
    public interface ITipoPrestamoService : IServiceCrud<TipoPrestamoDto, TipoPrestamoFormDto, int>, IServicePaginated<TipoPrestamoDto>
    {
    }
}
