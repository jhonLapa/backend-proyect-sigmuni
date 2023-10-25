using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoNormaIntereses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IProcedimientoNormaInteresService
    {
        Task<List<ProcedimientoNormaInteresDto>> CreateMultipleNormaInteres(List<ProcedimientoNormaInteresDto> normasIntereses, int idProcedimiento);
    }
}
