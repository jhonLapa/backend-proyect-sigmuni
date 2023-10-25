using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Monedas;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IMonedaService
    {
        Task<IList<MonedaDto>> FindAll();

    }
}
