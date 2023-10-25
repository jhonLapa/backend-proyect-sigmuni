using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.MedioRegistros;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IMedioRegistroService
    {
        Task<IList<MedioRegistroDto>> FindAll();

    }
}
