using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Litigantes;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ILitiganteService
    {
        Task<bool> EliminarPorIdFichaAsync(int idFicha);
        Task<Litigante> GuardarPersonaLitiganteAsync(PersonaLitiganteDto peticion);
        Task<Litigante> GuardarJuridicoaLitiganteAsync(PersonaLitiganteJuridicoDto peticion);
    }
}
