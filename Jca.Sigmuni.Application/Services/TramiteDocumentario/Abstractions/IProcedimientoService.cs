using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IProcedimientoService :IServiceCrud<ProcedimientoDto,ProcedimientoFormDto,int>,IServicePaginated<ProcedimientoDto> 
    {
        Task<IList<ProcedimientoDto>> FindTramite(int idTipoTramite);
        Task<ProcedimientoDto> CreateProcedimiento(ProcedimientoDto entity);
        Task<ProcedimientoDto> ObtenerUltimoSolicitud();
    }
}
