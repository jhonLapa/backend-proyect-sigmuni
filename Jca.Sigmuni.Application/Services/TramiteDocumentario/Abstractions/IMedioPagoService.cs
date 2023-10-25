using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.MedioPagos;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IMedioPagoService
    {
        Task<IList<MedioPagoDto>> FindAll();

    }
}
