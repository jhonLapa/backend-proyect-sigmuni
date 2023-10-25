using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoRequisitos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IProcedimientoRequisitoService
    {
        Task<IList<ProcedimientoRequisitoDto>> ListarPorProcedimiento(int idProcedimiento);
        Task<ProcedimientoRequisitoDto?> Disable(int id);
    }
}
